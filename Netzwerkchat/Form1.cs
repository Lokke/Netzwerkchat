namespace Netzwerkchat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Network network = new Network();
            network.initThreads();

        }
    }
}
