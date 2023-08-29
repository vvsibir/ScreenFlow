using System;
using System.IO;
using System.Xml.Serialization;

namespace ScreenFlowTest
{
    public class settings
    {
        public static settings current = new settings();

        int screen = 0;

        public int Width { get; set; }
        public int Height { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }

        public int Screen
        {
            get
            {
                return screen;
            }

            set
            {
                screen = value;
                OnSettingsChanged();
            }
        }

        int interval = 100;
        public int Interval
        {
            get
            {
                return interval;
            }

            set
            {
                interval = value;
                OnIntervalChanged();
                OnSettingsChanged();
            }
        }

        public bool ShowMouse { get; set; } = true;
        public bool AutoShow { get; set; }
        public bool AlwaysTop { get; set; } = true;
        public bool ResizeImage { get; set; } = true;
        public bool IconForm { get; set; } 

        public event EventHandler IntervalChanged;
        public void OnIntervalChanged()
        {
            if (IntervalChanged != null)
                IntervalChanged(this, null);
        }

        public event EventHandler SettingsChanged;
        public void OnSettingsChanged()
        {
            SettingsChanged?.Invoke(this, null);
        }

        public override string ToString()
        {
            string scrName = "ОШИБКА МОНИТОРА";
            if (System.Windows.Forms.Screen.AllScreens.Length > screen)
            {
                switch (screen)
                {
                    case 0:
                        scrName = "Первый монитор"; break;
                    case 1:
                        scrName = "Второй монитор"; break;
                    case 2:
                        scrName = "Третий монитор"; break;
                    case 3:
                        scrName = "Четвертый монитор"; break;
                    case 4:
                        scrName = "Пятый монитор"; break;
                    case 5:
                        scrName = "Шестой монитор"; break;
                    case 6:
                        scrName = "Седьмой монитор"; break;
                    case 7:
                        scrName = "Восьмой монитор"; break;
                    case 8:
                        scrName = "Девятый монитор"; break;
                    case 9:
                        scrName = "Десятый монитор"; break;
                    default:
                        scrName = System.Windows.Forms.Screen.AllScreens[screen].DeviceName;
                        break;
                }
            }
            return string.Format("{0}, {1:n0} раз в секунду", scrName, 1000/interval);
        }

        public static void Load(string path)
        {
            if (!File.Exists(path)) return;
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(settings));
                    settings.current = (settings)ser.Deserialize(fs);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(path);
                }
                catch
                {

                }
            }

        }
        public static void Save(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(settings));
                    ser.Serialize(fs, settings.current);

                    fs.Close();
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
