using System;
using System.IO;
using System.Text.Json;

namespace TP_MODUL9_103022400089
{


    using System;
    using System.IO;
    using System.Text.Json;

    public class CovidConfig
    {
        public string? satuan_suhu { get; set; }
        public string? batas_hari_demam { get; set; }
        public string? pesan_ditolak { get; set; }
        public string? pesan_diterima { get; set; }

        
        public int batasHariDemamInt;

        public CovidConfig()
        {
            LoadConfig();
        }

        public void LoadConfig()
        {
            try
            {
                string json = File.ReadAllText("covid_config.json");
                var data = JsonSerializer.Deserialize<CovidConfig>(json);

                if (data == null)
                {
                    SetDefault();
                    return;
                }

                satuan_suhu = GetValue(data.satuan_suhu);
                batas_hari_demam = GetValue(data.batas_hari_demam);
                pesan_ditolak = GetValue(data.pesan_ditolak);
                pesan_diterima = GetValue(data.pesan_diterima);

                batasHariDemamInt = int.Parse(batas_hari_demam);
            }
            catch
            {
                SetDefault();
            }
        }

        private string GetValue(string? key)
        {
            switch (key)
            {
                case "CONFIG1": return "celcius";
                case "CONFIG2": return "14";
                case "CONFIG3": return "Anda tidak diperbolehkan masuk ke dalam gedung ini";
                case "CONFIG4": return "Anda dipersilahkan untuk masuk ke dalam gedung ini";
                default: return key ?? "";
            }
        }

        private void SetDefault()
        {
            satuan_suhu = "celcius";
            batas_hari_demam = "14";
            pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

            batasHariDemamInt = 14;
        }

        public void UbahSatuan()
        {
            if (satuan_suhu == "celcius")
                satuan_suhu = "fahrenheit";
            else
                satuan_suhu = "celcius";
        }
    }
}
