using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bogosoft.Addressing
{
    /// <summary>
    /// A set of static members for working with ISO-3166-2 region codes.
    /// </summary>
    public static class RegionCode
    {
        /// <summary>
        /// Region codes specific to Canada.
        /// </summary>
        public static class Canada
        {
#pragma warning disable 1591
            public const string Alberta = "AB";
            public const string BritishColumbia = "BC";
            public const string Manitoba = "MB";
            public const string NewBrunswick = "NB";
            public const string NewfoundlandAndLabrador = "NL";
            public const string NovaScotia = "NS";
            public const string Ontario = "OS";
            public const string PrinceEdwardIsland = "PE";
            public const string Quebec = "QC";
            public const string Saskatchewan = "SK";
            public const string NorthwestTerritories = "NT";
            public const string Nunavut = "NU";
            public const string Yukon = "YT";
#pragma warning restore 1591
        }

        /// <summary>
        /// Region codes specific to the United Mexican States.
        /// </summary>
        public static class Mexico
        {
#pragma warning disable 1591
            public const string Aguascalientes = "AGU";
            public const string BajaCalifornia = "BCN";
            public const string BajaCaliforniaSur = "BCS";
            public const string Campeche = "CAM";
            public const string CiudadDeMéxico = "CMX";
            public const string CoahuilaDeZaragoza = "COA";
            public const string Colima = "COL";
            public const string Chiapas = "CHP";
            public const string Chihuahua = "CHH";
            public const string Durango = "DUR";
            public const string Guanajuato = "GUA";
            public const string Guerrero = "GRO";
            public const string Hidalgo = "HID";
            public const string Jalisco = "JAL";
            public const string México = "MEX";
            public const string MichoacánDeOcampo = "MIC";
            public const string Morelos = "MOR";
            public const string Nayarit = "NAY";
            public const string NuevoLeón = "NLE";
            public const string Oaxaca = "OAX";
            public const string Puebla = "PUE";
            public const string Querétaro = "QUE";
            public const string QuintanaRoo = "ROO";
            public const string SanLuisPotosí = "SLP";
            public const string Sinaloa = "SIN";
            public const string Sonora = "SON";
            public const string Tabasco = "TAB";
            public const string Tamaulipas = "TAM";
            public const string Tlaxcala = "TLA";
            public const string VeracruzDeIgnacioDeLaLlave = "VER";
            public const string Yucatán = "YUC";
            public const string Zacatecas = "ZAC";
#pragma warning restore 1591
        }

        /// <summary>
        /// Region codes specific to the United States of America.
        /// </summary>
        public static class UnitedStates
        {
#pragma warning disable 1591
            public const string Alabama = "AL";
            public const string Alaska = "AK";
            public const string Arizona = "AZ";
            public const string Arkansas = "AR";
            public const string AmericanSamoa = "AS";
            public const string California = "CA";
            public const string Colorado = "CO";
            public const string Connecticut = "CT";
            public const string DistrictOfColumbia = "DC";
            public const string Delaware = "DE";
            public const string Florida = "FL";
            public const string Georgia = "GA";
            public const string Guam = "GU";
            public const string Hawaii = "HI";
            public const string Idaho = "ID";
            public const string Illinois = "IL";
            public const string Indiana = "IN";
            public const string Iowa = "IA";
            public const string Kansas = "KS";
            public const string Kentucky = "KY";
            public const string Louisiana = "LA";
            public const string Maine = "ME";
            public const string Maryland = "MD";
            public const string Massachusetts = "MA";
            public const string Michigan = "MI";
            public const string Mississippi = "MS";
            public const string Missouri = "MO";
            public const string Montana = "MT";
            public const string Nebraska = "NE";
            public const string Nevada = "NV";
            public const string NewHampshire = "NH";
            public const string NewJersey = "NJ";
            public const string NewMexico = "NM";
            public const string NewYork = "NY";
            public const string NorthCarolina = "NC";
            public const string NorthDakota = "ND";
            public const string NorthernMarianaIslands = "MP";
            public const string Ohio = "OH";
            public const string Oklahoma = "OK";
            public const string Oregon = "OR";
            public const string Pennsylvania = "PA";
            public const string PuertoRico = "PR";
            public const string RhodeIsland = "RI";
            public const string SouthCarolina = "SC";
            public const string SouthDakota = "SD";
            public const string Tennessee = "TN";
            public const string Texas = "TX";
            public const string UnitedStatesMinorOutlyingIslands = "UM";
            public const string Utah = "UT";
            public const string Vermont = "VT";
            public const string Virginia = "VA";
            public const string VirginIslands = "VI";
            public const string Washington = "WA";
            public const string WestVirginia = "WV";
            public const string Wisconsin = "WI";
            public const string Wyoming = "WY";
#pragma warning restore 1591

            /// <summary>
            /// Get a collection of all United States region codes.
            /// </summary>
            public static IEnumerable<string> All
            {
                get
                {
                    return typeof(UnitedStates).GetFields(BindingFlags.Public | BindingFlags.Static)
                                               .Where(fi => fi.FieldType == typeof(string))
                                               .Select(fi => fi.GetValue(null))
                                               .Cast<string>();
                }
            }
        }
    }
}