using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ReviewMovie
{
    // Studio-style WinForms UI inspired by the provided Tailwind HTML layout.
    public sealed class MainForm : Form
    {
        private readonly string _appCode;
        private readonly string _apiKey;

        // Theme tokens (roughly matching the HTML sample)
        private static readonly Color StudioBg = ColorTranslator.FromHtml("#f1f5f9");
        private static readonly Color CardBg = Color.White;
        private static readonly Color Border = ColorTranslator.FromHtml("#e2e8f0");
        private static readonly Color Muted = ColorTranslator.FromHtml("#64748b");
        private static readonly Color Primary = ColorTranslator.FromHtml("#f97316");

        public MainForm(string appCode, string apiKey)
        {
            _appCode = appCode ?? string.Empty;
            _apiKey = apiKey ?? string.Empty;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            Text = "EasyClip Pro - Studio Edition";
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(1100, 750);
            BackColor = StudioBg;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = StudioBg,
                ColumnCount = 1,
                RowCount = 3,
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 108));

            var topNav = BuildTopNav();
            var main = BuildMainArea();
            var bottomBar = BuildBottomBar();

            root.Controls.Add(topNav, 0, 0);
            root.Controls.Add(main, 0, 1);
            root.Controls.Add(bottomBar, 0, 2);

            Controls.Add(root);

            ResumeLayout(true);
        }

        private Control BuildTopNav()
        {
            var nav = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(14, 10, 14, 10),
            };

            nav.Paint += (s, e) =>
            {
                using (var p = new Pen(Border, 1))
                {
                    e.Graphics.DrawLine(p, 0, nav.Height - 1, nav.Width, nav.Height - 1);
                }
            };

            var left = new FlowLayoutPanel
            {
                Dock = DockStyle.Left,
                AutoSize = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.Transparent,
                Padding = new Padding(0),
                Margin = new Padding(0),
            };

            var logo = new RoundedPanel
            {
                Size = new Size(36, 36),
                BackColor = Primary,
                CornerRadius = 9,
                Margin = new Padding(0, 0, 10, 0),
            };
            var logoText = new Label
            {
                Dock = DockStyle.Fill,
                Text = "EC",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            logo.Controls.Add(logoText);

            var titleWrap = new Panel { AutoSize = true, BackColor = Color.Transparent };
            var title = new Label
            {
                AutoSize = true,
                Text = "EasyClip Pro",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#0f172a"),
            };
            var subtitle = new Label
            {
                AutoSize = true,
                Text = "STUDIO EDITION • v2.4.0",
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                ForeColor = Primary,
                Margin = new Padding(0, 0, 0, 0)
            };
            titleWrap.Controls.Add(title);
            titleWrap.Controls.Add(subtitle);
            title.Location = new Point(0, 0);
            subtitle.Location = new Point(0, 18);
            titleWrap.Size = new Size(220, 34);

            left.Controls.Add(logo);
            left.Controls.Add(titleWrap);

            var right = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.Transparent,
                Padding = new Padding(0),
                Margin = new Padding(0),
            };

            var cloudPill = new RoundedPanel
            {
                AutoSize = true,
                BackColor = ColorTranslator.FromHtml("#f1f5f9"),
                CornerRadius = 16,
                Padding = new Padding(10, 6, 10, 6),
                Margin = new Padding(0, 2, 10, 0),
            };
            var dot = new Panel
            {
                Size = new Size(8, 8),
                BackColor = ColorTranslator.FromHtml("#22c55e"),
                Margin = new Padding(2, 4, 6, 0),
            };
            dot.Paint += (s, e) => ApplyCircleClip(dot);
            var cloudText = new Label
            {
                AutoSize = true,
                Text = "CLOUD SYNC ACTIVE",
                ForeColor = Muted,
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                Margin = new Padding(0, 0, 0, 0),
            };
            cloudPill.Controls.Add(dot);
            cloudPill.Controls.Add(cloudText);
            cloudPill.Layout += (s, e) =>
            {
                dot.Location = new Point(10, (cloudPill.Height - dot.Height) / 2);
                cloudText.Location = new Point(dot.Right + 6, (cloudPill.Height - cloudText.Height) / 2);
                cloudPill.Width = cloudText.Right + 10;
            };

            var accountBtn = CreateGhostIconButton("Account");
            accountBtn.Text = "👤";
            accountBtn.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Regular);
            accountBtn.Click += (s, e) =>
            {
                MessageBox.Show($"AppCode: {_appCode}\nAPI Key: {MaskKey(_apiKey)}", "Session", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            };

            right.Controls.Add(cloudPill);
            right.Controls.Add(accountBtn);

            nav.Controls.Add(right);
            nav.Controls.Add(left);

            return nav;
        }

        private Control BuildMainArea()
        {
            var main = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = StudioBg,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(14, 14, 14, 14),
            };
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66));
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34));

            var leftScroll = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.Transparent };
            var rightScroll = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.Transparent };

            var leftStack = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
            };
            leftStack.Controls.Add(BuildVoiceCenterCard());
            leftStack.Controls.Add(BuildTimelineCard());

            var rightStack = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
            };
            rightStack.Controls.Add(BuildCurrentProjectCard());
            rightStack.Controls.Add(BuildVoiceSettingsCard());
            rightStack.Controls.Add(BuildOutputQualityCard());
            rightStack.Controls.Add(BuildVideoOptionsCard());
            rightStack.Controls.Add(BuildVolumeSpeedCard());
            rightStack.Controls.Add(BuildVoiceLanguageCard());
            rightStack.Controls.Add(BuildConfigCard());

            leftScroll.Controls.Add(leftStack);
            rightScroll.Controls.Add(rightStack);

            main.Controls.Add(leftScroll, 0, 0);
            main.Controls.Add(rightScroll, 1, 0);

            return main;
        }

        private Control BuildVoiceCenterCard()
        {
            var card = CreateCard(980);

            var header = BuildCardHeader("Voice Center", "settings_voice");
            var headerActions = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.Transparent,
            };
            headerActions.Controls.Add(CreateGhostButton("IMPORT SCRIPT", 112));
            headerActions.Controls.Add(CreateGhostButton("PREVIEW ALL", 96));
            header.Controls.Add(headerActions);
            headerActions.Location = new Point(header.Width - headerActions.Width - 8, 8);
            headerActions.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            var body = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent,
                Padding = new Padding(0, 8, 0, 0),
            };
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170));
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            var live = new RoundedPanel
            {
                BackColor = ColorTranslator.FromHtml("#fef2f2"),
                CornerRadius = 14,
                Padding = new Padding(10),
                Margin = new Padding(0, 0, 12, 0),
                Height = 100,
                Dock = DockStyle.Fill,
            };
            var liveIcon = new RoundedPanel
            {
                Size = new Size(40, 40),
                CornerRadius = 20,
                BackColor = ColorTranslator.FromHtml("#ef4444"),
                Margin = new Padding(0, 6, 0, 8),
            };
            var liveIconText = new Label
            {
                Dock = DockStyle.Fill,
                Text = "🎙",
                ForeColor = Color.White,
                Font = new Font("Segoe UI Emoji", 12F),
                TextAlign = ContentAlignment.MiddleCenter,
            };
            liveIcon.Controls.Add(liveIconText);
            var liveText = new Label
            {
                AutoSize = true,
                Text = "Live Record",
                ForeColor = ColorTranslator.FromHtml("#dc2626"),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
            };
            live.Controls.Add(liveIcon);
            live.Controls.Add(liveText);
            live.Layout += (s, e) =>
            {
                liveIcon.Left = (live.Width - liveIcon.Width) / 2;
                liveIcon.Top = 14;
                liveText.Left = (live.Width - liveText.Width) / 2;
                liveText.Top = liveIcon.Bottom + 10;
            };

            var script = new TextBox
            {
                Multiline = true,
                Height = 100,
                ScrollBars = ScrollBars.Vertical,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 9F),
                ForeColor = ColorTranslator.FromHtml("#0f172a"),
                BackColor = ColorTranslator.FromHtml("#f8fafc"),
                Dock = DockStyle.Fill,
                Text = "",
            };
            script.GotFocus += (s, e) => script.BackColor = Color.White;
            script.LostFocus += (s, e) => script.BackColor = ColorTranslator.FromHtml("#f8fafc");
            // .NET Framework 4.8 TextBox doesn't support PlaceholderText; emulate it.
            const string placeholder = "Paste your script segments here for processing...";
            script.Text = placeholder;
            script.ForeColor = Muted;
            script.Enter += (s, e) =>
            {
                if (script.Text == placeholder)
                {
                    script.Text = string.Empty;
                    script.ForeColor = ColorTranslator.FromHtml("#0f172a");
                }
            };
            script.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(script.Text))
                {
                    script.Text = placeholder;
                    script.ForeColor = Muted;
                }
            };

            body.Controls.Add(live, 0, 0);
            body.Controls.Add(script, 1, 0);

            card.Controls.Add(body);
            card.Controls.Add(header);

            return card;
        }

        private Control BuildTimelineCard()
        {
            var card = CreateCard(980);
            card.Padding = new Padding(0);

            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 44,
                BackColor = ColorTranslator.FromHtml("#f8fafc"),
                Padding = new Padding(14, 10, 14, 10),
            };
            header.Paint += (s, e) =>
            {
                using (var p = new Pen(ColorTranslator.FromHtml("#f1f5f9"), 1))
                {
                    e.Graphics.DrawLine(p, 0, header.Height - 1, header.Width, header.Height - 1);
                }
            };

            var title = new Label
            {
                AutoSize = true,
                Text = "MEDIA TIMELINE",
                ForeColor = ColorTranslator.FromHtml("#94a3b8"),
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
            };
            header.Controls.Add(title);
            title.Location = new Point(0, 12);

            var actions = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
            };
            actions.Controls.Add(CreateSolidButton("+ NEW ITEM", ColorTranslator.FromHtml("#16a34a"), 92));
            actions.Controls.Add(CreateSolidButton("GENERATE SUBTITLES", ColorTranslator.FromHtml("#2563eb"), 140));
            header.Controls.Add(actions);

            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = CardBg,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeight = 34,
                EnableHeadersVisualStyles = false,
                Font = new Font("Segoe UI", 9F),
            };
            grid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f8fafc");
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Muted;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#0f172a");
            grid.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#f1f5f9");
            grid.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#0f172a");
            grid.GridColor = ColorTranslator.FromHtml("#f1f5f9");

            var colCheck = new DataGridViewCheckBoxColumn { HeaderText = "Check", FillWeight = 50, Width = 60 };
            var colNo = new DataGridViewTextBoxColumn { HeaderText = "No.", FillWeight = 60, Width = 60 };
            var colLen = new DataGridViewTextBoxColumn { HeaderText = "Length" };
            var colAudio = new DataGridViewTextBoxColumn { HeaderText = "Audio Time" };
            var colLink = new DataGridViewTextBoxColumn { HeaderText = "Media Link" };
            var colStatus = new DataGridViewTextBoxColumn { HeaderText = "Status" };
            var colAct = new DataGridViewTextBoxColumn { HeaderText = "Actions", FillWeight = 70 };
            grid.Columns.AddRange(colCheck, colNo, colLen, colAudio, colLink, colStatus, colAct);

            grid.Rows.Add(true, "01", "00:12:40", "00:08:15", "assets/clip_v1.mp4", "Encoded", "...");
            grid.Rows.Add(false, "02", "00:05:15", "00:04:30", "assets/intro_bg.mp4", "Processing", "...");

            // Slight styling for important columns
            grid.CellFormatting += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                if (grid.Columns[e.ColumnIndex].HeaderText == "Audio Time")
                {
                    e.CellStyle.ForeColor = Primary;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            };

            var body = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0) };
            body.Controls.Add(grid);

            card.Controls.Add(body);
            card.Controls.Add(header);

            return card;
        }

        private Control BuildCurrentProjectCard()
        {
            var card = CreateCard(420);
            var label = CreateLabel("Current Project", isLabel: true);
            var row = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 34,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent,
            };
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 84));

            var select = CreateComboBox();
            select.Items.AddRange(new object[] { "Marketing_Launch_2024", "YouTube_Short_Teaser" });
            select.SelectedIndex = 0;

            var create = CreatePrimaryButton("CREATE", 80);
            create.Click += (s, e) => MessageBox.Show("Create project (placeholder)", "Project", MessageBoxButtons.OK, MessageBoxIcon.Information);

            row.Controls.Add(select, 0, 0);
            row.Controls.Add(create, 1, 0);

            card.Controls.Add(row);
            card.Controls.Add(label);
            return card;
        }

        private Control BuildVoiceSettingsCard()
        {
            var card = CreateCard(420);
            var header = BuildSmallCardTitle("Voice Settings", "record_voice_over");

            var stack = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
            };

            stack.Controls.Add(CreateLabel("Source", isLabel: true));
            var src = CreateComboBox();
            src.Items.Add("ElevenLabs API");
            src.SelectedIndex = 0;
            stack.Controls.Add(src);

            stack.Controls.Add(CreateLabel("API Key", isLabel: true));
            var key = CreateTextBox(password: true);
            key.Text = _apiKey;
            stack.Controls.Add(key);

            var save = CreateGhostButton("SAVE API CONFIG", 0);
            save.Dock = DockStyle.Top;
            save.Width = card.Width - 28;
            save.Click += (s, e) => MessageBox.Show("Saved (placeholder).", "Voice Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            stack.Controls.Add(save);

            card.Controls.Add(stack);
            card.Controls.Add(header);
            return card;
        }

        private Control BuildOutputQualityCard()
        {
            var card = CreateCard(420);
            var header = BuildSmallCardTitle("Output Quality", "high_quality");

            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                BackColor = Color.Transparent,
                ColumnCount = 2,
                RowCount = 6,
                Margin = new Padding(0),
            };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            grid.Controls.Add(CreateLabel("Zoom %", isLabel: true), 0, 0);
            grid.Controls.Add(CreateLabel("FPS", isLabel: true), 1, 0);
            var zoom = CreateTextBox();
            zoom.Text = "100";
            var fps = CreateTextBox();
            fps.Text = "60";
            grid.Controls.Add(zoom, 0, 1);
            grid.Controls.Add(fps, 1, 1);

            grid.Controls.Add(CreateLabel("ZQuality", isLabel: true), 0, 2);
            grid.Controls.Add(CreateLabel("Thread", isLabel: true), 1, 2);
            var q = CreateComboBox();
            q.Items.Add("Ultra");
            q.SelectedIndex = 0;
            var th = CreateTextBox();
            th.Text = "8";
            grid.Controls.Add(q, 0, 3);
            grid.Controls.Add(th, 1, 3);

            var profileLabel = CreateLabel("Quality Profile", isLabel: true);
            grid.Controls.Add(profileLabel, 0, 4);
            grid.SetColumnSpan(profileLabel, 2);

            var profile = new TrackBar
            {
                Dock = DockStyle.Top,
                Height = 28,
                TickStyle = TickStyle.None,
                Minimum = 0,
                Maximum = 100,
                Value = 65,
            };
            grid.Controls.Add(profile, 0, 5);
            grid.SetColumnSpan(profile, 2);

            var btnRow = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 34,
                ColumnCount = 2,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 10, 0, 0),
            };
            btnRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            btnRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            btnRow.Controls.Add(CreateGhostButton("SCALE ALL", 0), 0, 0);
            btnRow.Controls.Add(CreateGhostButton("EFFECTS", 0), 1, 0);

            card.Controls.Add(btnRow);
            card.Controls.Add(grid);
            card.Controls.Add(header);
            return card;
        }

        private Control BuildVideoOptionsCard()
        {
            var card = CreateCard(420);
            var header = BuildSmallCardTitle("Video Options", null);

            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                BackColor = Color.Transparent,
                ColumnCount = 2,
                RowCount = 3,
            };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            grid.Controls.Add(CreateCheck("Zoom", true), 0, 0);
            grid.Controls.Add(CreateCheck("Rotate", false), 1, 0);
            grid.Controls.Add(CreateCheck("Flip", false), 0, 1);
            grid.Controls.Add(CreateCheck("Flip Random", false), 1, 1);

            var autoMove = CreateCheck("Auto Move Player Layer", true);
            grid.Controls.Add(autoMove, 0, 2);
            grid.SetColumnSpan(autoMove, 2);

            card.Controls.Add(grid);
            card.Controls.Add(header);
            return card;
        }

        private Control BuildVolumeSpeedCard()
        {
            var card = CreateCard(420);
            var header = BuildSmallCardTitle("Volume & Speed", null);

            var volRow = new Panel { Dock = DockStyle.Top, Height = 20, BackColor = Color.Transparent };
            var volLabel = CreateLabel("Original", isLabel: true);
            volLabel.Location = new Point(0, 0);
            var volValue = new Label
            {
                AutoSize = true,
                Text = "80%",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#0f172a"),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            volRow.Controls.Add(volLabel);
            volRow.Controls.Add(volValue);
            volRow.Resize += (s, e) => volValue.Location = new Point(volRow.Width - volValue.Width, 0);

            var volume = new TrackBar
            {
                Dock = DockStyle.Top,
                Height = 28,
                TickStyle = TickStyle.None,
                Minimum = 0,
                Maximum = 100,
                Value = 80,
            };
            volume.ValueChanged += (s, e) => volValue.Text = $"{volume.Value}%";

            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                BackColor = Color.Transparent,
                ColumnCount = 2,
                RowCount = 2,
                Margin = new Padding(0, 10, 0, 0),
            };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            grid.Controls.Add(CreateLabel("Audio Scale", isLabel: true), 0, 0);
            grid.Controls.Add(CreateLabel("Read Speed", isLabel: true), 1, 0);
            var scale = CreateTextBox();
            scale.Text = "1.0x";
            var speed = CreateTextBox();
            speed.Text = "1.15x";
            grid.Controls.Add(scale, 0, 1);
            grid.Controls.Add(speed, 1, 1);

            card.Controls.Add(grid);
            card.Controls.Add(volume);
            card.Controls.Add(volRow);
            card.Controls.Add(header);
            return card;
        }

        private Control BuildVoiceLanguageCard()
        {
            var card = CreateCard(420);
            var header = BuildSmallCardTitle("Voice & Language", null);

            var stack = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
            };

            stack.Controls.Add(CreateLabel("Language Selection", isLabel: true));
            var lang = CreateComboBox();
            lang.Items.AddRange(new object[] { "English (United States)", "Spanish (ES)" });
            lang.SelectedIndex = 0;
            stack.Controls.Add(lang);

            stack.Controls.Add(CreateLabel("Voice Reader", isLabel: true));
            var voice = CreateComboBox();
            voice.Items.AddRange(new object[] { "Adam (Deep Narrative)", "Bella (Energetic)" });
            voice.SelectedIndex = 0;
            stack.Controls.Add(voice);

            card.Controls.Add(stack);
            card.Controls.Add(header);
            return card;
        }

        private Control BuildConfigCard()
        {
            var card = CreateCard(420);

            var header = new Panel { Dock = DockStyle.Top, Height = 30, BackColor = Color.Transparent };
            var title = new Label
            {
                AutoSize = true,
                Text = "CONFIGURATION",
                ForeColor = ColorTranslator.FromHtml("#94a3b8"),
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Location = new Point(0, 8),
            };
            var save = new LinkLabel
            {
                AutoSize = true,
                Text = "SAVE ALL",
                LinkColor = Primary,
                ActiveLinkColor = Primary,
                VisitedLinkColor = Primary,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
            };
            save.Click += (s, e) => MessageBox.Show("Saved all (placeholder).", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            header.Controls.Add(title);
            header.Controls.Add(save);
            header.Resize += (s, e) => save.Location = new Point(header.Width - save.Width, 8);

            card.Controls.Add(header);
            return card;
        }

        private Control BuildBottomBar()
        {
            var bar = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(248, 255, 255, 255),
                Padding = new Padding(14, 12, 14, 12),
            };
            bar.Paint += (s, e) =>
            {
                using (var p = new Pen(Border, 1))
                {
                    e.Graphics.DrawLine(p, 0, 0, bar.Width, 0);
                }
            };

            var left = new FlowLayoutPanel
            {
                Dock = DockStyle.Left,
                AutoSize = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.Transparent,
            };

            var engineWrap = new Panel { Width = 300, Height = 70, BackColor = Color.Transparent };
            var engineLabel = CreateLabel("Rendering Engine", isLabel: true);
            engineLabel.Location = new Point(0, 0);
            var enginePill = new RoundedPanel
            {
                CornerRadius = 10,
                BackColor = ColorTranslator.FromHtml("#f1f5f9"),
                Padding = new Padding(4),
                Size = new Size(160, 34),
                Location = new Point(0, 24),
            };
            var cpu = new RadioButton
            {
                Text = "CPU",
                Checked = true,
                Appearance = Appearance.Button,
                FlatStyle = FlatStyle.Flat,
                AutoSize = false,
                Size = new Size(74, 26),
                Location = new Point(4, 4),
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                BackColor = Color.White,
            };
            cpu.FlatAppearance.BorderColor = Border;
            var gpu = new RadioButton
            {
                Text = "GPU",
                Appearance = Appearance.Button,
                FlatStyle = FlatStyle.Flat,
                AutoSize = false,
                Size = new Size(74, 26),
                Location = new Point(80, 4),
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#f1f5f9"),
                ForeColor = Muted
            };
            gpu.FlatAppearance.BorderSize = 0;
            enginePill.Controls.Add(cpu);
            enginePill.Controls.Add(gpu);
            engineWrap.Controls.Add(engineLabel);
            engineWrap.Controls.Add(enginePill);

            var etaWrap = new Panel { Width = 160, Height = 70, BackColor = Color.Transparent, Margin = new Padding(16, 0, 0, 0) };
            var etaLabel = CreateLabel("Estimated Time", isLabel: true);
            etaLabel.Location = new Point(0, 0);
            var etaValue = new Label
            {
                AutoSize = true,
                Text = "00:04:15",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#334155"),
                Location = new Point(0, 28),
            };
            etaWrap.Controls.Add(etaLabel);
            etaWrap.Controls.Add(etaValue);

            left.Controls.Add(engineWrap);
            left.Controls.Add(etaWrap);

            var merge = new Button
            {
                Text = "MERGE SECTIONS",
                Dock = DockStyle.Right,
                Height = 62,
                Width = 260,
                FlatStyle = FlatStyle.Flat,
                BackColor = Primary,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
            };
            merge.FlatAppearance.BorderSize = 0;
            merge.Click += (s, e) => MessageBox.Show("Merge sections (placeholder).", "Render", MessageBoxButtons.OK, MessageBoxIcon.Information);

            bar.Controls.Add(merge);
            bar.Controls.Add(left);

            return bar;
        }

        private Panel BuildCardHeader(string titleText, string _)
        {
            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 38,
                BackColor = Color.Transparent,
                Padding = new Padding(0, 2, 0, 0),
            };

            var title = new Label
            {
                AutoSize = true,
                Text = titleText.ToUpperInvariant(),
                ForeColor = ColorTranslator.FromHtml("#94a3b8"),
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Location = new Point(0, 10),
            };
            header.Controls.Add(title);

            return header;
        }

        private Control BuildSmallCardTitle(string text, string _)
        {
            var header = new Panel { Dock = DockStyle.Top, Height = 28, BackColor = Color.Transparent };
            var title = new Label
            {
                AutoSize = true,
                Text = text.ToUpperInvariant(),
                ForeColor = ColorTranslator.FromHtml("#94a3b8"),
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Location = new Point(0, 6),
            };
            header.Controls.Add(title);
            return header;
        }

        private StudioCard CreateCard(int width)
        {
            return new StudioCard
            {
                Width = width,
                BackColor = CardBg,
                BorderColor = Border,
                CornerRadius = 14,
                Padding = new Padding(14, 12, 14, 14),
                Margin = new Padding(0, 0, 0, 14),
            };
        }

        private static Label CreateLabel(string text, bool isLabel)
        {
            return new Label
            {
                AutoSize = true,
                Text = isLabel ? text.ToUpperInvariant() : text,
                ForeColor = isLabel ? ColorTranslator.FromHtml("#64748b") : ColorTranslator.FromHtml("#0f172a"),
                Font = isLabel ? new Font("Segoe UI", 7.5F, FontStyle.Bold) : new Font("Segoe UI", 9F, FontStyle.Regular),
                Margin = new Padding(0, 0, 0, isLabel ? 6 : 0),
            };
        }

        private static ComboBox CreateComboBox()
        {
            return new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F),
                Height = 28,
                Margin = new Padding(0, 0, 0, 10),
            };
        }

        private static TextBox CreateTextBox(bool password = false)
        {
            return new TextBox
            {
                UseSystemPasswordChar = password,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = ColorTranslator.FromHtml("#f8fafc"),
                ForeColor = ColorTranslator.FromHtml("#0f172a"),
                Font = new Font("Segoe UI", 9F),
                Height = 28,
                Margin = new Padding(0, 0, 0, 10),
            };
        }

        private static CheckBox CreateCheck(string text, bool value)
        {
            return new CheckBox
            {
                Text = text,
                Checked = value,
                AutoSize = true,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                ForeColor = ColorTranslator.FromHtml("#334155"),
                Margin = new Padding(0, 0, 0, 8),
            };
        }

        private static Button CreatePrimaryButton(string text, int width)
        {
            var btn = new Button
            {
                Text = text,
                FlatStyle = FlatStyle.Flat,
                BackColor = Primary,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Height = 28,
                Width = width > 0 ? width : 90,
                Margin = new Padding(0, 0, 0, 10),
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private static Button CreateSolidButton(string text, Color color, int width)
        {
            var btn = new Button
            {
                Text = text,
                FlatStyle = FlatStyle.Flat,
                BackColor = color,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Height = 24,
                Width = width,
                Margin = new Padding(0, 0, 8, 0),
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private static Button CreateGhostButton(string text, int width)
        {
            var btn = new Button
            {
                Text = text,
                FlatStyle = FlatStyle.Flat,
                BackColor = ColorTranslator.FromHtml("#f1f5f9"),
                ForeColor = ColorTranslator.FromHtml("#334155"),
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Height = 24,
                Width = width > 0 ? width : 160,
                Margin = new Padding(0, 0, 8, 0),
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private static Button CreateGhostIconButton(string tooltip)
        {
            var btn = new Button
            {
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Muted,
                Width = 36,
                Height = 36,
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 0, 0, 0),
            };
            btn.FlatAppearance.BorderSize = 0;
            new ToolTip().SetToolTip(btn, tooltip);
            return btn;
        }

        private static void ApplyCircleClip(Control c)
        {
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, c.Width - 1, c.Height - 1);
                c.Region = new Region(gp);
            }
        }

        private static string MaskKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return string.Empty;
            if (key.Length <= 6) return new string('*', key.Length);
            return key.Substring(0, 3) + new string('*', Math.Max(0, key.Length - 6)) + key.Substring(key.Length - 3);
        }
    }

    internal sealed class StudioCard : RoundedPanel
    {
        public Color BorderColor { get; set; } = ColorTranslator.FromHtml("#e2e8f0");

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (var path = GetRoundedRectPath(new Rectangle(0, 0, Width - 1, Height - 1), CornerRadius))
            using (var pen = new Pen(BorderColor, 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
    }

    internal class RoundedPanel : Panel
    {
        public int CornerRadius { get; set; } = 12;

        public RoundedPanel()
        {
            DoubleBuffered = true;
            Resize += (s, e) => ApplyRegion();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ApplyRegion();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = GetRoundedRectPath(new Rectangle(0, 0, Width - 1, Height - 1), CornerRadius))
            using (var brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        protected void ApplyRegion()
        {
            if (Width <= 2 || Height <= 2) return;
            using (var path = GetRoundedRectPath(new Rectangle(0, 0, Width, Height), CornerRadius))
            {
                Region = new Region(path);
            }
        }

        protected static GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int d = Math.Max(1, radius) * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}

