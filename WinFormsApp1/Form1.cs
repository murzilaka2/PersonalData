using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private GroupBox groupBox;
        public Form1()
        {
            InitializeComponent();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Анкета";
            (Height, Width) = (360, 300);
            (MaximizeBox, FormBorderStyle) = (false, FormBorderStyle.Fixed3D);

            groupBox = new GroupBox()
            {
                Text = "Анкета",
                Padding = new Padding(10),
                Size = new Size(ClientSize.Width - 20, ClientSize.Height - 50),
                Location = new Point(10, 10)
            };

            int labelWidth = (int)(groupBox.ClientSize.Width / 2.75), labelHeight = 20;
            string[] texts = { "Фамилия", "Имя", "Отчество", "Страна", "Телефон", "Дата Рождения", "Пол" };
            string[] textBoxNames = { "SurNameTextBox", "NameTextBox", "MiddleNameTextBox", "CountryTextBox", "PhoneTextBox", "DateTextBox" };
            float padding = 2;

            for (int i = 0; i < texts.Length; i++)
            {
                if (i == 3 || i == 5)
                {
                    padding += 1.5f;
                }
                groupBox.Controls.Add(new Label
                {
                    Text = texts[i],
                    Size = new Size(labelWidth, labelHeight),
                    Location = new Point(5, (int)(labelHeight * (i + padding)))
                });

                if (i < texts.Length - 1)
                {
                    groupBox.Controls.Add(new TextBox()
                    {
                        Name = textBoxNames[i],
                        Size = new Size((int)(labelWidth * 1.5), labelHeight),
                        Location = new Point(labelWidth + 5, (int)(labelHeight * (i + padding))),
                        Tag = texts[i]
                    });
                }
                if (i == texts.Length - 1)
                {
                    groupBox.Controls.Add(new RadioButton()
                    {
                        Name = "Man",
                        Text = "Мужской",
                        Checked = true,
                        Location = new Point(labelWidth + 5, (int)(labelHeight * (i + padding))),
                        Width = 80
                    });

                    groupBox.Controls.Add(new RadioButton()
                    {
                        Name = "Woman",
                        Text = "Женский",
                        Location = new Point(labelWidth + 85, (int)(labelHeight * (i + padding))),
                        Width = 80
                    });
                }
            }
            this.Controls.Add(groupBox);

            Button button = new Button
            {
                Height = 30,
                Width = groupBox.Width,
                Location = new Point(groupBox.Left, groupBox.Bottom + 5),
                Text = "Посмотреть результаты"
            };
            button.Click += (sender, e) =>
            {
                var st = new StringBuilder(200);
                foreach (var item in groupBox.Controls.OfType<TextBox>())
                {
                    st.Append($"{item.Tag} - {item.Text}");
                }
                st.Append($"Пол: {groupBox.Controls.OfType<RadioButton>().FirstOrDefault(e=>e.Checked).Text}");
                MessageBox.Show(st.ToString(),"Анкетные данные");
            };
            this.Controls.Add(button);
        }
    }
}