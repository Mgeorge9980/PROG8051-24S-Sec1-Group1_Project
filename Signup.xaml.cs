using System.Windows;

using System.Windows.Controls;

using System.Windows.Media;



namespace YourNamespace

{

    public static class PlaceholderService

    {

        public static readonly DependencyProperty PlaceholderProperty =

            DependencyProperty.RegisterAttached(

                "Placeholder",

                typeof(string),

                typeof(PlaceholderService),

                new PropertyMetadata(default(string), OnPlaceholderChanged));



        public static string GetPlaceholder(UIElement element)

        {

            return (string)element.GetValue(PlaceholderProperty);

        }



        public static void SetPlaceholder(UIElement element, string value)

        {

            element.SetValue(PlaceholderProperty, value);

        }



        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)

        {

            if (d is TextBox textBox)

            {

                textBox.GotFocus -= RemovePlaceholder;

                textBox.LostFocus -= ShowPlaceholder;



                if (!string.IsNullOrEmpty((string)e.NewValue))

                {

                    textBox.GotFocus += RemovePlaceholder;

                    textBox.LostFocus += ShowPlaceholder;

                }



                ShowPlaceholder(textBox, null);

            }

            else if (d is PasswordBox passwordBox)

            {

                passwordBox.GotFocus -= RemovePasswordPlaceholder;

                passwordBox.LostFocus -= ShowPasswordPlaceholder;



                if (!string.IsNullOrEmpty((string)e.NewValue))

                {

                    passwordBox.GotFocus += RemovePasswordPlaceholder;

                    passwordBox.LostFocus += ShowPasswordPlaceholder;

                }



                ShowPasswordPlaceholder(passwordBox, null);

            }

        }



        private static void RemovePlaceholder(object sender, RoutedEventArgs e)

        {

            if (sender is TextBox textBox && textBox.Text == GetPlaceholder(textBox))

            {

                textBox.Text = string.Empty;

                textBox.Foreground = SystemColors.ControlTextBrush;

            }

        }



        private static void ShowPlaceholder(object sender, RoutedEventArgs e)

        {

            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))

            {

                textBox.Text = GetPlaceholder(textBox);

                textBox.Foreground = SystemColors.GrayTextBrush;

            }

        }



        private static void RemovePasswordPlaceholder(object sender, RoutedEventArgs e)

        {

            if (sender is PasswordBox passwordBox && passwordBox.Password == GetPlaceholder(passwordBox))

            {

                passwordBox.Password = string.Empty;

                passwordBox.Foreground = SystemColors.ControlTextBrush;

            }

        }



        private static void ShowPasswordPlaceholder(object sender, RoutedEventArgs e)

        {

            if (sender is PasswordBox passwordBox && string.IsNullOrWhiteSpace(passwordBox.Password))

            {

                passwordBox.Password = GetPlaceholder(passwordBox);

                passwordBox.Foreground = SystemColors.GrayTextBrush;

            }

        }

    }

}