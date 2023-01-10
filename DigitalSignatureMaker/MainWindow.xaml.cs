using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace DigitalSignatureMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Btn512_Click(object sender, RoutedEventArgs e)
        {
            OneWayEncyption oneway = new OneWayEncyption();
            string text = this.SourceText.Text.Trim();
            DigitalSignature.Text = oneway.Sha512(text);
            DigitalSignature.FontSize = 11;
            ReceivedFromSender.FontSize= 11;
            BitsUsed.Text = "512 Bits";
            AnimateBackgroundColor(SourceText,  Colors.LightGreen, Colors.White);
            AnimateBackgroundColor(DigitalSignature, Colors.LightGreen, Colors.White);
        }

        

        private void Btn384_Click(object sender, RoutedEventArgs e)
        {
            OneWayEncyption oneway = new OneWayEncyption();
            string text = this.SourceText.Text.Trim();
            DigitalSignature.Text = oneway.Sha384(text);
            DigitalSignature.FontSize = 15;
            ReceivedFromSender.FontSize = 15;
            BitsUsed.Text = "384 Bits";
            AnimateBackgroundColor(SourceText, Colors.LightGreen, Colors.White);
            AnimateBackgroundColor(DigitalSignature, Colors.LightGreen, Colors.White);
        }

        private void Btn256_Click(object sender, RoutedEventArgs e)
        {
            OneWayEncyption oneway = new OneWayEncyption();
            string text = this.SourceText.Text.Trim();
            DigitalSignature.Text = oneway.Sha256(text);
            DigitalSignature.FontSize = 18;
            ReceivedFromSender.FontSize = 18;
            BitsUsed.Text = "256 Bits";
            AnimateBackgroundColor(SourceText, Colors.LightGreen, Colors.White);
            AnimateBackgroundColor(DigitalSignature, Colors.LightGreen, Colors.White);
        }

        

        private void BtnTextex1_Click(object sender, RoutedEventArgs e)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("SHA-512 is a cryptographic hash function that is ");
            sb.AppendLine("intended to generate hash values that are resistant ");
            sb.AppendLine("to hacker attacks. Because it is too fast, it should ");
            sb.AppendLine("not be used as a password hashing function. When a ");
            sb.AppendLine("user logs in, the password is hashed and compared to ");
            sb.AppendLine("the previously stored hash. The user is authenticated ");
            sb.AppendLine("if the hashes match. An attacker can easily determine if ");
            sb.AppendLine("their guess is correct by comparing it to the stored ");
            sb.AppendLine("hash if they can quickly guess a password and generate ");
            sb.AppendLine("its hash. This is referred to as a \"rainbow table attack.\"");
            sb.AppendLine();
            sb.AppendLine("To counteract this, password hashing functions are designed ");
            sb.AppendLine("to be slow, requiring an attacker to expend significant time ");
            sb.AppendLine("and resources in order to generate hashes for a large number ");
            sb.AppendLine("of password guesses. This makes a rainbow table attack more ");
            sb.AppendLine("difficult for an attacker. Because SHA-512 is intended to ");
            sb.AppendLine("be fast, it is unsuitable for use as a password hashing ");
            sb.AppendLine("function.");
            sb.AppendLine();
            sb.AppendLine("Other cryptographic hash functions, such as bcrypt and scrypt, are ");
            sb.AppendLine("specifically designed for password hashing. Because these functions ");
            sb.AppendLine("are slower than SHA-512, they are more resistant to rainbow table attacks.");
            sb.AppendLine("For password hashing, it is generally recommended to use one of ");
            sb.AppendLine("these functions rather than SHA-512.");

            SourceText.Text= sb.ToString();
        }


        private void CompareSignatures_Click(object sender, RoutedEventArgs e)
        {
            if(this.DigitalSignature.Text.ToString().Length>0)
            {
                if(this.ReceivedFromSender.Text.ToString().Length>0)
                {
                    if(this.DigitalSignature.Text == this.ReceivedFromSender.Text)
                    {
                        this.DigitalSignature.Background = new SolidColorBrush(Colors.LightGreen);
                        this.ReceivedFromSender.Background = new SolidColorBrush(Colors.LightGreen);
                    }
                    else
                    {
                        this.DigitalSignature.Background = new SolidColorBrush(Colors.LightPink);
                        this.ReceivedFromSender.Background = new SolidColorBrush(Colors.LightPink);

                    }
                }
                else
                {
                    AnimateBackgroundColor(ReceivedFromSender, Colors.Pink, Colors.White);
                    MessageBox.Show("Nothing to compare", "No RECV value");
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            this.DigitalSignature.Background = new SolidColorBrush(Colors.White);
            this.ReceivedFromSender.Background = new SolidColorBrush(Colors.White);
            this.DigitalSignature.Text = "";
            this.ReceivedFromSender.Text = "";
            this.SourceText.Text = "";
            this.BitsUsed.Text = "";
            AnimateBackgroundColor(SourceText, Colors.LightSkyBlue,Colors.White);
            AnimateBackgroundColor(DigitalSignature, Colors.LightSkyBlue, Colors.White);
            AnimateBackgroundColor(ReceivedFromSender, Colors.LightSkyBlue, Colors.White);
        }



        private void AnimateBackgroundColor(System.Windows.Controls.TextBox tb, Color from, Color to)
        {
            ColorAnimation animation;
            animation = new ColorAnimation();
            animation.From = from;
            animation.To = to;
            animation.Duration = new Duration(TimeSpan.FromSeconds(1));
            tb.Background = new SolidColorBrush(from);
            tb.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }

    }
}
