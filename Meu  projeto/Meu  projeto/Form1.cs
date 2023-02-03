using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Meu__projeto
{
    public partial class Form1 : Form
    {

        TextBox usernameTextBox;
        TextBox passwordTextBox;
        public Form1()
        {
            InitializeComponent();
            // Cria o frame superior na cor laranja
            Panel topFrame = new Panel();
            topFrame.BackColor = System.Drawing.Color.Orange;
            topFrame.Dock = DockStyle.Top;
            topFrame.Height = 150;
            this.Controls.Add(topFrame);
            //Cria o frame  inferior  na cor branca
            Panel bottomFrame = new Panel();
            bottomFrame.BackColor = System.Drawing.Color.White;
            bottomFrame.Dock = DockStyle.Bottom;
            bottomFrame.Height = 618;


            // Add text boxes to bottom frame


            Label nomeLabel = new Label();
            nomeLabel.Text = "Nome:";
            nomeLabel.Location = new System.Drawing.Point(450, 225);
            nomeLabel.Size = new System.Drawing.Size(75, 30);
            bottomFrame.Controls.Add(nomeLabel);

            TextBox usernameTextBox = new TextBox();
            usernameTextBox.Location = new System.Drawing.Point(460, 225);
            usernameTextBox.Size = new System.Drawing.Size(200, 30);
            bottomFrame.Controls.Add(usernameTextBox);

            Label passwordLabel = new Label();
            passwordLabel.Text = "Senha:";
            passwordLabel.Location = new System.Drawing.Point(690, 225);
            passwordLabel.Size = new System.Drawing.Size(75, 30);
            bottomFrame.Controls.Add(passwordLabel);


            TextBox passwordTextBox = new TextBox();
            passwordTextBox.Location = new System.Drawing.Point(700, 225);
            passwordTextBox.Size = new System.Drawing.Size(200, 30);
            bottomFrame.Controls.Add(passwordTextBox);


            // Add buttons to bottom frame
            Button submitButton = new Button();
            submitButton.Click += new EventHandler(submitButton_Click);
            submitButton.Text = "Entrar";
            submitButton.Location = new System.Drawing.Point(530, 300);
            submitButton.Size = new System.Drawing.Size(85, 25);
            bottomFrame.Controls.Add(submitButton);

            Button trocarButton = new Button();
            trocarButton.Text = "Trocar usuario";
            trocarButton.Location = new System.Drawing.Point(630, 300);
            trocarButton.Size = new System.Drawing.Size(85, 25);
            bottomFrame.Controls.Add(trocarButton);

            Button cancelButton = new Button();
            cancelButton.Click += new EventHandler(CancelButton_Click);
            cancelButton.Text = "Sair";
            cancelButton.Location = new System.Drawing.Point(730, 300);
            cancelButton.Size = new System.Drawing.Size(85, 25);
            bottomFrame.Controls.Add(cancelButton);


            this.Controls.Add(bottomFrame);



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=<server_name>;Initial Catalog=<database_name>;Integrated Security=True;";
            string nome = usernameTextBox.Text;
            string senha = passwordTextBox.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM usuarios WHERE Nome=@Nome AND Senha=@Senha";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Senha", senha);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Bem-vindo, " + nome + "!");
                        }
                        else
                        {
                            MessageBox.Show("Nome de usuário ou senha incorretos.");
                        }
                    }
                }
            }
        }
    }

}
