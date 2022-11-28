using System.Collections.Generic;

namespace HomeControl.Dictionaries
{
    public class EntityNames
    {
        public static Dictionary<string, string> Lights = new Dictionary<string, string>()
        {
            //Salon
            {"light.salon_lights","Salon - Grupa"},
            {"light.light1","Salon L1"},
            {"light.salon_2","Salon - L2"},
            {"light.salon_3","Salon L3"},

            //Kuchnia
            {"light.kuchnia_led_lights","Kuchnia LED - Grupa"},
            {"light.light4","Kuchnia"},
            {"light.led2","Kuchnia - sufit"},
            {"light.led1","Kuchnia - podłoga"},

            //Sypialnia
            {"light.light2","Sypialnia"},
            {"light.sypialnia_led","Sypialnia - LED"},

            //Pozostałe
            {"light.light3","Łazienka"},
            {"light.light5","Przedpokój"},
            {"light.led3","PC LED"},
        };
    }
}
