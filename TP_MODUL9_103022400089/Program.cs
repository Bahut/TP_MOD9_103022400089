using System;
using TP_MODUL9_103022400089;


class Program
{
    static void Main()
    {
        CovidConfig config = new CovidConfig();

        Console.Write("Berapa suhu badan anda saat ini? Dalam nilai " + config.satuan_suhu + ": ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu anda terakhir demam :  ");
        int hari = Convert.ToInt32(Console.ReadLine());

        bool suhuValid = false;

        if (config.satuan_suhu == "celcius")
        {
            suhuValid = (suhu >= 36.5 && suhu <= 37.5);
        }
        else
        {
            suhuValid = (suhu >= 97.7 && suhu <= 99.5);
        }

        if (suhuValid && hari < config.batasHariDemamInt)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }
        config.UbahSatuan();
        Console.WriteLine("Satuan sekarang: " + config.satuan_suhu);
    }
}