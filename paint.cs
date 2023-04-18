using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;
// mcs -pkg:dotnet -r:System.Windows.Forms Program.cs

public class Program : Form
{
    private TextBox textBox;
    private PictureBox pictureBox;

    public Program()
    {
        // Configurações do formulário
        this.Text = "Exemplo de programa";
        this.BackColor = Color.Blue;
        this.ClientSize = new Size(400, 300);

        // Configurações do textbox
        this.textBox = new TextBox();
        this.textBox.Location = new Point(10, 10);
        this.textBox.Size = new Size(200, 100);
        this.textBox.BackColor = Color.White;
        this.Controls.Add(this.textBox);

        // Configurações da picturebox
        this.pictureBox = new PictureBox();
        this.pictureBox.Location = new Point(220, 10);
        this.pictureBox.Size = new Size(170, 280);
        this.pictureBox.BackColor = Color.Blue;
        this.pictureBox.Image = new Bitmap(800, 800);
        this.Controls.Add(this.pictureBox);

        // Evento do botão de envio
        
        Button sendButton = new Button();
        sendButton.Text = "Enviar";
        sendButton.Location = new Point(10, 120);
        sendButton.Size = new Size(100, 30);
        sendButton.Click += new EventHandler(this.OnSendButtonClick);
        this.Controls.Add(sendButton);
    }

    private void OnSendButtonClick(object sender, EventArgs e)
    {
        // Faz o parse do comando
        string command = this.textBox.Text;
        string[] parts = command.Split(',');
        if (parts.Length != 5 || parts[0] != "line")
        {
            MessageBox.Show("Comando inválido");
            return;
        }

        // Desenha a linha na picturebox
        int x1 = int.Parse(parts[1]);
        int y1 = int.Parse(parts[2]);
        int x2 = int.Parse(parts[3]);
        int y2 = int.Parse(parts[4]);
        using (Graphics g = Graphics.FromImage(this.pictureBox.Image))
        {
            g.DrawLine(Pens.White, x1, y1, x2, y2);
        }
        this.pictureBox.Invalidate();
    }

    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Program());
    }
}
