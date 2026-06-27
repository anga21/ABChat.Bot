using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VAchatBox2;

namespace VAchatBox2
{
    public partial class ChatForm : Form
    {

        private readonly ResponseEngine _engine = new ResponseEngine();
        private string _userName = "User";

        
        private List<QuizQuestion> _quizQuestions;
        private int _quizIndex;
        private int _quizScore;
        private bool _quizActive = false;

       
        private bool _awaitingTaskDesc = false;
        private bool _awaitingTaskReminder = false;
        private string _pendingTaskTitle = "";
        private string _pendingTaskDesc = "";

        private List<CyberTask> _loadedTasks = new List<CyberTask>();

        public ChatForm()
        {
            InitializeComponent();
            AskForName();
        }

        private void AskForName()
        {
            using (var dlg = new Form())
            {
                dlg.Text = "Welcome to ABChat";
                dlg.Size = new Size(400, 170);
                dlg.BackColor = Color.FromArgb(15, 30, 58);
                dlg.ForeColor = Color.White;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;

                var lbl = new Label
                {
                    Text = "Please enter your name to get started:",
                    ForeColor = Color.FromArgb(0, 200, 220),
                    Location = new Point(14, 18),
                    AutoSize = true
                };
                var txt = new TextBox
                {
                    Location = new Point(14, 46),
                    Width = 358,
                    BackColor = Color.FromArgb(20, 40, 70),
                    ForeColor = Color.White,
                    Font = new Font("Consolas", 10f),
                    BorderStyle = BorderStyle.FixedSingle
                };
                var btn = new Button
                {
                    Text = "Start Chatting ➤",
                    Location = new Point(14, 82),
                    Width = 358,
                    Height = 36,
                    BackColor = Color.FromArgb(0, 200, 220),
                    ForeColor = Color.Black,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Consolas", 10f, FontStyle.Bold)
                };
                btn.Click += (s, e) => {
                    if (!string.IsNullOrWhiteSpace(txt.Text))
                    {
                        _userName = txt.Text.Trim();
                        _engine.UserName = _userName;
                        dlg.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Please enter your name.");
                    }
                };
                txt.KeyDown += (s, e) => {
                    if (e.KeyCode == Keys.Enter) btn.PerformClick();
                };

                dlg.Controls.AddRange(new Control[] { lbl, txt, btn });
                dlg.ShowDialog(this);
            }

            AppendChat("ABChat",
                $"Welcome, {_userName}! I am your Cybersecurity Awareness Bot.\n\n" +
                $"Ask me about:  passwords · phishing · malware · 2fa · wifi · privacy · browsing · social\n\n" +
                $"Commands you can type:\n" +
                $"  'add task Enable 2FA'          — add a security task\n" +
                $"  'remind me to update password' — set a reminder task\n" +
                $"  'show my tasks'                — list your tasks\n" +
                $"  'show activity log'            — see recent actions\n" +
                $"  'start quiz'                   — test your knowledge\n\n" +
                $"Or click  Quiz  to begin!",
                Color.FromArgb(0, 200, 220));

            DatabaseManager.LogAction($"Session started — user: {_userName}");
            _engine.AddToSessionLog($"Session started for {_userName}.");
            LoadTasks();
            LoadLog();
        }

        
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendMessage();
            }
        }

        private void btnQuiz_Click(object sender, EventArgs e)
        {
            StartQuiz();
        }

        private void SendMessage()
        {
            string input = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;
            txtInput.Clear();

            if (_quizActive)
            {
                AppendChat(_userName, input, Color.FromArgb(255, 210, 50));
                HandleQuizAnswer(input);
                return;
            }

            if (_awaitingTaskDesc) { HandleTaskDescInput(input); return; }
            if (_awaitingTaskReminder) { HandleTaskReminderInput(input); return; }

            AppendChat(_userName, input, Color.FromArgb(255, 210, 50));
            string response = _engine.GetResponse(input);

            if (response == "QUIT_SIGNAL")
            {
                AppendChat("ABChat",
                    $"Goodbye, {_userName}! Stay cyber-safe.", Color.FromArgb(0, 200, 220));
                DatabaseManager.LogAction($"User {_userName} ended session.");
                return;
            }

            if (response == "QUIZ_SIGNAL") { StartQuiz(); return; }
            if (response == "TASK_VIEW_SIGNAL") { ShowTasksInChat(); return; }

            if (response.StartsWith("TASK_ADD_SIGNAL:"))
            {
                NlpBeginAddTask(response.Substring("TASK_ADD_SIGNAL:".Length));
                return;
            }

            if (response.StartsWith("TASK_REMIND_SIGNAL:"))
            {
                NlpBeginRemindTask(response.Substring("TASK_REMIND_SIGNAL:".Length));
                return;
            }

            AppendChat("ABChat", response, Color.White);
            DatabaseManager.LogAction($"{_userName} asked: {input}");
        }

        private void NlpBeginAddTask(string rawInput)
        {
            string title = ExtractAfterKeyword(rawInput,
                new[] { "add task", "create task", "new task",
                        "add a task", "i need to", "set a task" });

            if (!string.IsNullOrEmpty(title))
            {
                _pendingTaskTitle = title;
                _awaitingTaskDesc = true;
                AppendChat("ABChat",
                    $"Got it! I will add the task: \"{title}\"\n\n" +
                    "Please type a short description (or type 'skip' to leave blank):",
                    Color.FromArgb(0, 200, 220));
            }
            else
            {
                _pendingTaskTitle = "";
                _awaitingTaskDesc = true;
                AppendChat("ABChat",
                    "Sure! What is the title of the task you want to add?",
                    Color.FromArgb(0, 200, 220));
            }
        }

        private void NlpBeginRemindTask(string rawInput)
        {
            string title = ExtractAfterKeyword(rawInput,
                new[] { "remind me to", "remind me", "set reminder for",
                        "set a reminder for", "reminder for" });

            _pendingTaskTitle = string.IsNullOrEmpty(title) ? "Reminder" : title;
            _pendingTaskDesc = "Reminder set via chat.";
            _awaitingTaskReminder = true;

            AppendChat("ABChat",
                $"I will set a reminder for: \"{_pendingTaskTitle}\"\n\n" +
                "In how many days? (e.g. '3'), or type a date (e.g. '2025-12-01'), or type 'skip':",
                Color.FromArgb(0, 200, 220));
        }

        private void HandleTaskDescInput(string input)
        {
            AppendChat(_userName, input, Color.FromArgb(255, 210, 50));

            if (_pendingTaskTitle == "")
            {
                _pendingTaskTitle = input;
                AppendChat("ABChat",
                    $"Task title set to \"{_pendingTaskTitle}\".\n\n" +
                    "Please type a short description (or 'skip'):",
                    Color.FromArgb(0, 200, 220));
                return;
            }

            _pendingTaskDesc = input.ToLower() == "skip" ? "" : input;
            _awaitingTaskDesc = false;
            _awaitingTaskReminder = true;

            AppendChat("ABChat",
                "Would you like a reminder? Type the number of days (e.g. '7'), " +
                "a date (e.g. '2025-12-01'), or 'skip':",
                Color.FromArgb(0, 200, 220));
        }

        private void HandleTaskReminderInput(string input)
        {
            AppendChat(_userName, input, Color.FromArgb(255, 210, 50));
            _awaitingTaskReminder = false;

            DateTime? reminder = null;

            if (input.ToLower() != "skip")
            {
                if (int.TryParse(input.Trim(), out int days) && days > 0)
                    reminder = DateTime.Today.AddDays(days);
                else if (DateTime.TryParse(input.Trim(), out DateTime parsed))
                    reminder = parsed;
                else
                    AppendChat("ABChat",
                        "Could not parse that date — saving task without a reminder.",
                        Color.FromArgb(160, 175, 200));
            }

            try
            {
                DatabaseManager.AddTask(_pendingTaskTitle, _pendingTaskDesc, reminder);

                string logEntry = $"Task added via chat: {_pendingTaskTitle}" +
                                  (reminder.HasValue
                                      ? $" (Reminder: {reminder.Value:dd MMM yyyy})" : "");
                DatabaseManager.LogAction(logEntry);
                _engine.AddToSessionLog(logEntry);

                AppendChat("ABChat",
                    $"Task added: \"{_pendingTaskTitle}\"\n" +
                    (reminder.HasValue
                        ? $"Reminder set for {reminder.Value:dd MMM yyyy}."
                        : "No reminder set."),
                    Color.FromArgb(0, 190, 110));

                LoadTasks();
                LoadLog();
            }
            catch (Exception ex)
            {
                AppendChat("ABChat", "Could not save task: " + ex.Message,
                    Color.FromArgb(220, 60, 60));
            }

            _pendingTaskTitle = "";
            _pendingTaskDesc = "";
        }

        private void ShowTasksInChat()
        {
            try
            {
                var tasks = DatabaseManager.GetAllTasks();
                if (tasks.Count == 0)
                {
                    AppendChat("ABChat",
                        "You have no tasks yet. Type 'add task' to create one!",
                        Color.FromArgb(0, 200, 220));
                    return;
                }

                string msg = $"Here are your tasks, {_userName}:\n\n";
                int show = Math.Min(tasks.Count, 10);
                for (int i = 0; i < show; i++)
                {
                    var t = tasks[i];
                    string status = t.IsCompleted ? "✔" : "○";
                    string remind = t.Reminder.HasValue
                        ? $"  Reminder: {t.Reminder.Value:dd MMM yyyy}" : "";
                    msg += $"  {i + 1}. {status}  {t.Title}{remind}\n";
                }
                AppendChat("ABChat", msg, Color.FromArgb(0, 200, 220));
            }
            catch (Exception ex)
            {
                AppendChat("ABChat", "Could not load tasks: " + ex.Message,
                    Color.FromArgb(220, 60, 60));
            }
        }

        private string ExtractAfterKeyword(string input, string[] keywords)
        {
            string lower = input.ToLower();
            foreach (string kw in keywords)
            {
                int idx = lower.IndexOf(kw);
                if (idx >= 0)
                {
                    string after = input.Substring(idx + kw.Length)
                                        .Trim(" :-".ToCharArray());
                    if (!string.IsNullOrEmpty(after)) return after;
                }
            }
            return "";
        }

        private void StartQuiz()
        {
            _quizQuestions = QuizEngine.GetRandomQuestions(6);
            _quizIndex = 0;
            _quizScore = 0;
            _quizActive = true;
            tabControl.SelectedTab = tabChat;

            AppendChat("ABChat",
                "CYBER QUIZ STARTING!\n\n" +
                "Multiple-choice: type the NUMBER of your answer (1, 2, 3 or 4).\n" +
                "True / False: type  1  for True  or  2  for False.\n\nGood luck!",
                Color.FromArgb(180, 0, 220));

            _engine.AddToSessionLog($"Quiz started by {_userName}.");
            DatabaseManager.LogAction($"{_userName} started the quiz.");
            ShowQuizQuestion();
        }

        private void ShowQuizQuestion()
        {
            var q = _quizQuestions[_quizIndex];
            string header = q.IsTrueFalse ? "[ TRUE / FALSE ]" : "[ MULTIPLE CHOICE ]";
            string txt = $"Q{_quizIndex + 1} of {_quizQuestions.Count}  {header}" +
                            $"\n\n{q.Question}\n\n";
            for (int i = 0; i < q.Options.Length; i++)
                txt += $"  {i + 1}.  {q.Options[i]}\n";

            AppendChat("Quiz", txt, Color.FromArgb(0, 200, 220));
        }

        private void HandleQuizAnswer(string input)
        {
            int max = _quizQuestions[_quizIndex].Options.Length;

            if (!int.TryParse(input.Trim(), out int choice) ||
                choice < 1 || choice > max)
            {
                AppendChat("Quiz",
                    $"Please type a number between 1 and {max}.",
                    Color.FromArgb(180, 0, 220));
                return;
            }

            var q = _quizQuestions[_quizIndex];
            bool correct = (choice - 1) == q.CorrectIndex;

            if (correct)
            {
                _quizScore++;
                AppendChat("Quiz",
                    $"Correct!\n\n{q.Explanation}",
                    Color.FromArgb(0, 190, 110));
            }
            else
            {
                AppendChat("Quiz",
                    $"Not quite.\nCorrect answer: {q.Options[q.CorrectIndex]}\n\n{q.Explanation}",
                    Color.FromArgb(220, 60, 60));
            }

            _quizIndex++;

            if (_quizIndex >= _quizQuestions.Count)
            {
                _quizActive = false;
                int total = _quizQuestions.Count;
                string grade =
                    _quizScore == total ? "Perfect score! You are a cybersecurity pro!" :
                    _quizScore >= total - 1 ? "Excellent! Almost perfect!" :
                    _quizScore >= (total / 2) ? "Good effort! Keep learning to stay safe." :
                                                "Keep practising — cybersecurity knowledge saves you!";

                AppendChat("Quiz",
                    $"\nQuiz Complete!\n\nYou scored  {_quizScore} / {total}\n\n{grade}",
                    Color.FromArgb(255, 210, 50));

                string logEntry = $"Quiz completed — score {_quizScore}/{total}.";
                _engine.AddToSessionLog(logEntry);
                DatabaseManager.LogAction($"{_userName}: {logEntry}");
                LoadLog();
            }
            else
            {
                ShowQuizQuestion();
            }
        }

       
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = txtTaskTitle.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter a task title.", "Missing Title",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime? reminder = chkReminder.Checked
                ? dtpReminder.Value : (DateTime?)null;

            try
            {
                string desc = txtTaskDesc.Text.Trim();
                DatabaseManager.AddTask(title, desc, reminder);

                string logEntry = $"Task added: {title}" +
                                  (reminder.HasValue
                                      ? $" (Reminder: {reminder.Value:dd MMM yyyy})" : "");
                DatabaseManager.LogAction(logEntry);
                _engine.AddToSessionLog(logEntry);

                txtTaskTitle.Clear();
                txtTaskDesc.Clear();
                chkReminder.Checked = false;
                LoadTasks();
                LoadLog();

                AppendChat("ABChat",
                    $"Task added: \"{title}\"\n" +
                    (reminder.HasValue
                        ? $"Reminder set for {reminder.Value:dd MMM yyyy}."
                        : "No reminder set."),
                    Color.FromArgb(0, 190, 110));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save task:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            int idx = lstTasks.SelectedIndex;
            if (idx < 0 || idx >= _loadedTasks.Count) return;

            var task = _loadedTasks[idx];
            try
            {
                DatabaseManager.MarkCompleted(task.Id);
                string logEntry = $"Task marked complete: {task.Title}";
                DatabaseManager.LogAction(logEntry);
                _engine.AddToSessionLog(logEntry);
                LoadTasks();
                LoadLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            int idx = lstTasks.SelectedIndex;
            if (idx < 0 || idx >= _loadedTasks.Count) return;

            var task = _loadedTasks[idx];
            if (MessageBox.Show(
                    $"Delete task \"{task.Title}\"?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                DatabaseManager.DeleteTask(task.Id);
                string logEntry = $"Task deleted: {task.Title}";
                DatabaseManager.LogAction(logEntry);
                _engine.AddToSessionLog(logEntry);
                LoadTasks();
                LoadLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkReminder_CheckedChanged(object sender, EventArgs e)
        {
            dtpReminder.Visible = chkReminder.Checked;
        }

        private void btnRefreshLog_Click(object sender, EventArgs e)
        {
            LoadLog();
        }

        private void LoadTasks()
        {
            try
            {
                _loadedTasks = DatabaseManager.GetAllTasks();
                lstTasks.Items.Clear();
                foreach (var t in _loadedTasks)
                {
                    string status = t.IsCompleted ? "[Done]" : "[  ]";
                    string remind = t.Reminder.HasValue
                        ? $"  Reminder: {t.Reminder.Value:dd MMM yyyy}" : "";
                    lstTasks.Items.Add($"{status}  {t.Title}{remind}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load tasks:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadLog()
        {
            try
            {
                var entries = DatabaseManager.GetRecentLog(30);
                lstLog.Items.Clear();
                foreach (string entry in entries)
                    lstLog.Items.Add(entry);
            }
            catch
            {
                lstLog.Items.Clear();
                lstLog.Items.Add("Could not load log — check DB connection.");
            }
        }

        private void AppendChat(string speaker, string message, Color color)
        {
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionLength = 0;
            rtbChat.SelectionColor = color;
            rtbChat.AppendText($"\n[{speaker}]\n{message}\n");
            rtbChat.SelectionColor = Color.White;
            rtbChat.ScrollToCaret();
        }
    }
}