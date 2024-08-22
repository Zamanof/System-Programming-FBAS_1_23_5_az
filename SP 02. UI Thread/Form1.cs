namespace SP_02._UI_Thread;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        new Thread(() =>
        {
            button1.Enabled = false;
            for (int i = 0; i < 100; i++)
            {
                label2.Text = i.ToString();
                Thread.Sleep(100);
            }
        }).Start();
        button1.Enabled = true;

    }
}
