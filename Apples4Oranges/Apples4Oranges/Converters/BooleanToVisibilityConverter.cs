using System;
using System.Globalization;
using Xamarin.Forms;

namespace Apples4Oranges.Converters
{

    public class InvertedBoolenConverter : IValueConverter
    {

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            if (value is bool)
                return !(bool) value;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public sealed class BaseTypeToStringFormatConverter : IValueConverter
    {
        private string _format = String.Empty;

        public string Format
        {
            get { return _format; }
            set { _format = value; }
        }

        private string _prefix = String.Empty;

        public string Prefix
        {
            get { return _prefix; }
            set { _prefix = value; }
        }

        private string _suffix = String.Empty;

        public string Suffix
        {
            get { return _suffix; }
            set { _suffix = value; }
        }

        public bool ConverToLocalTime { get; set; }

        public bool Capitalize { get; set; }

        public bool Uppercase { get; set; }

        public bool Lowercase { get; set; }

        public bool Trim { get; set; }

        public bool ConvertDateToTodayTomorrow { get; set; }

        private string FormatValue(string value)
        {
            if (Capitalize)
                return value.ToUpper();
            if (Lowercase)
                return value.ToLower();
            if (Uppercase)
                return value.ToUpper();
            if (Trim)
                return value.Trim();
            return value;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                DateTime showValue = (DateTime)value;

                if (showValue == DateTime.MinValue)
                    return String.Empty;

                if (ConverToLocalTime)
                    showValue = showValue.ToLocalTime();

                string returnValue = _format != String.Empty ? showValue.ToString(_format) : showValue.ToString(CultureInfo.InvariantCulture);

                if (ConvertDateToTodayTomorrow)
                {
                    // If the remaining days value in double is less than 2.0
                    if ((showValue - DateTime.Now).TotalDays >= 0 && (showValue - DateTime.Now).TotalDays < 2.0)
                    {
                        int splitLength;
                        switch (_format)
                        {
                            case "d MMM yyyy":
                            case "d MMM yyyy hh:mm tt":
                                splitLength = 10;
                                break;
                            case "dd MMM yyyy":
                            case "dd MMM yyyy hh:mm tt":
                                splitLength = 11;
                                break;
                            default:
                                splitLength = 0;
                                break;
                        }
                        // If the format matched then replace the date with "Today" or "Tomorrow"
                        if (splitLength > 0)
                        {
                            string todayTomorrowString = (showValue - DateTime.Now).TotalDays < 1.0
                                    ? "Today"
                                    : "Tomorrow";
                            returnValue = returnValue.Remove(0, splitLength).Insert(0, todayTomorrowString);
                        }
                    }
                }

                return Prefix + FormatValue(returnValue) + Suffix;
            }

            if (value is DateTimeOffset)
            {
                DateTimeOffset showValue = (DateTimeOffset)value;

                if (showValue == DateTimeOffset.MinValue)
                    return String.Empty;
                // If the Server does not return a UTC of +00:00 then just display the DateTime -> else display the Local Time
                showValue = ConverToLocalTime ? showValue.ToLocalTime() : showValue.DateTime;

                string returnValue = _format != String.Empty ? showValue.ToString(_format) : showValue.ToString(CultureInfo.InvariantCulture);

                if (ConvertDateToTodayTomorrow)
                {
                    // If the remaining days value in double is less than 2.0
                    if ((showValue - DateTime.Today).TotalDays >= 0 && (showValue - DateTime.Today).TotalDays < 2.0)
                    {
                        int splitLength;
                        switch (_format)
                        {
                            case "d MMM yyyy":
                            case "d MMMM yyyy":
                            case "d MMMM yy":
                            case "dd MMM yyyy":
                            case "dd MMMM yyyy":
                            case "dd MMMM yy":
                                splitLength = returnValue.Length;
                                break;
                            case "d MMM yyyy hh:mm tt":
                            case "dd MMM yyyy hh:mm tt":
                                splitLength = 8;
                                break;
                            case "d MMM yyyy h:mm tt":
                            case "d MMMM yyyy h:mm tt":
                            case "d MMM yy h:mm tt":
                            case "d MMMM yy h:mm tt":
                                splitLength = 7;
                                break;
                            case "d MMM yyyy @ hh:mm tt":
                                splitLength = 11;
                                break;
                            case "d MMM yyyy @ h:mm tt":
                            case "dd MMM yyyy @ h:mm tt":
                                splitLength = 10;
                                break;
                            default:
                                splitLength = 0;
                                break;
                        }
                        // If the format matched then replace the date with "Today" or "Tomorrow"
                        if (splitLength > 0)
                        {
                            string todayTomorrowString = (showValue - DateTime.Today).TotalDays < 1.0
                                    ? "Today"
                                    : "Tomorrow";
                            char[] charArray = returnValue.ToCharArray();
                            Array.Reverse(charArray);
                            string reverseString = new string(charArray);

                            // Remove the Date Part and then reverse it again
                            string newReverseString = reverseString.Remove(splitLength, reverseString.Length - splitLength);
                            char[] newCharArray = newReverseString.ToCharArray();
                            Array.Reverse(newCharArray);

                            newReverseString = new string(newCharArray);

                            returnValue = todayTomorrowString + newReverseString;
                        }
                    }
                }
                return Prefix + FormatValue(returnValue) + Suffix;
            }


            return Prefix + FormatValue(value.ToString()) + Suffix;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Not Supported to Convert Back");
        }
    }
}
