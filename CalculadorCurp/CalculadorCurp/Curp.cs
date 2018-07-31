namespace CalculadorCurp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CalculadorCurp.Extensions;

    /// <summary>
    /// The curp.
    /// </summary>
    public class Curp
    {
        /// <summary>
        ///     Las Palabras inconvenientes.
        /// </summary>
        public readonly HashSet<string> PalabrasInconvenientes = new HashSet<string>
        {
            "BACA", "BAKA", "BUEI", "BUEY",
            "CACA", "CACO", "CAGA", "CAGO", "CAKA", "CAKO", "COGE", "COGI", "COJA", "COJE", "COJI", "COJO", "COLA", "CULO",
            "FALO", "FETO",
            "GETA", "GUEI", "GUEY",
            "JETA", "JOTO",
            "KACA", "KACO", "KAGA", "KAGO", "KAKA", "KAKO", "KOGE", "KOGI", "KOJA", "KOJE", "KOJI", "KOJO", "KOLA", "KULO",
            "LILO", "LOCA", "LOCO", "LOKA", "LOKO",
            "MAME", "MAMO", "MEAR", "MEAS", "MEON", "MIAR", "MION", "MOCO", "MOKO", "MULA", "MULO",
            "NACA", "NACO",
            "PEDA", "PEDO", "PENE", "PIPI", "PITO", "POPO", "PUTA", "PUTO",
            "QULO",
            "RATA", "ROBA", "ROBE", "ROBO", "RUIN",
            "SENO",
            "TETA",
            "VACA", "VAGA", "VAGO", "VAKA", "VUEI", "VUEY",
            "WUEI", "WUEY"
        };

        /// <summary>
        ///     Directorio de estados.
        /// </summary>
        public readonly Dictionary<Estado, string> Estados = new Dictionary<Estado, string>
        {
            { Estado.Aguascalientes, "AS" },
            { Estado.Baja_California, "BC" },
            { Estado.Baja_California_Sur, "BS" },
            { Estado.Campeche, "CC" },
            { Estado.Chiapas, "CS" },
            { Estado.Chihuahua, "CH" },
            { Estado.Coahuila, "CL" },
            { Estado.Colima, "CM" },
            { Estado.Distrito_Federal, "DF" },
            { Estado.Durango, "DG" },
            { Estado.Guanajuato, "GT" },
            { Estado.Guerrero, "GR" },
            { Estado.Hidalgo, "HG" },
            { Estado.Jalisco, "JC" },
            { Estado.Mexico, "MC" },
            { Estado.Morelos, "MS" },
            { Estado.Michoacan, "MN" },
            { Estado.Nayarit, "NT" },
            { Estado.Nuevo_Leon, "NL" },
            { Estado.Oaxaca, "OC" },
            { Estado.Puebla, "PL" },
            { Estado.Queretaro, "QT" },
            { Estado.Quintana_Roo, "QR" },
            { Estado.San_Luis_Potosi, "SP" },
            { Estado.Sinaloa, "SL" },
            { Estado.Sonora, "SR" },
            { Estado.Tabasco, "TC" },
            { Estado.Tamaulipas, "TS" },
            { Estado.Tlaxcala, "TL" },
            { Estado.Veracruz, "VZ" },
            { Estado.Yucatan, "YN" },
            { Estado.Zacatecas, "ZS" },
            { Estado.Extranjero, "NE" }
        };

        /// <summary>
        ///     La Clave Única de Registro de Población.
        /// </summary>
        public readonly string CURP;

        /// <summary>
        ///     El estado o entidad federativa de nacimiento.
        /// </summary>
        public readonly Estado Estado;

        /// <summary>
        ///     La fecha de nacimiento.
        /// </summary>
        public readonly DateTime FechaNacimiento;

        /// <summary>
        ///     El apellido materno.
        /// </summary>
        public readonly string Materno;

        /// <summary>
        ///     Los nombres.
        /// </summary>
        public readonly string Nombres;

        /// <summary>
        ///     El apellido paterno.
        /// </summary>
        public readonly string Paterno;

        /// <summary>
        ///     El sexo.
        /// </summary>
        public readonly Sexo Sexo;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Curp"/> class.
        /// </summary>
        /// <param name="nombres"> Los nombres.</param>
        /// <param name="paterno"> El apellido paterno.</param>
        /// <param name="materno"> El apellido materno.</param>
        /// <param name="sexo"> El sexo.</param>
        /// <param name="fechaNacimiento"> La fecha de nacimiento.</param>
        /// <param name="estado"> El estado o entidad federativa de nacimiento.</param>
        public Curp(string nombres, string paterno, string materno, Sexo sexo, DateTime fechaNacimiento, Estado estado)
        {
            this.Nombres = nombres;
            this.Paterno = paterno;
            this.Materno = materno;
            this.FechaNacimiento = fechaNacimiento;
            this.Estado = estado;
            this.Sexo = sexo;

            this.CURP = this.CalculaCurp();
        }

        /// <summary>
        ///     Calcula el codigo verificador en base a la pre CURP.
        /// </summary>
        /// <param name="preCURP"> La pre CURP.</param>
        /// <returns> El código verificador.</returns>
        /// <exception cref="ArgumentException"> Cuando alguno de los caracteres de la pre CURP no es válido.</exception>
        private static int CodigoVerificador(string preCURP)
        {
            var contador = 18;
            var sumatoria = 0;

            // Por cada caracter
            foreach (var caracter in preCURP)
            {
                int valor;

                switch (caracter)
                {
                    case '0':
                        valor = 0 * contador;
                        break;
                    case '1':
                        valor = 1 * contador;
                        break;
                    case '2':
                        valor = 2 * contador;
                        break;
                    case '3':
                        valor = 3 * contador;
                        break;
                    case '4':
                        valor = 4 * contador;
                        break;
                    case '5':
                        valor = 5 * contador;
                        break;
                    case '6':
                        valor = 6 * contador;
                        break;
                    case '7':
                        valor = 7 * contador;
                        break;
                    case '8':
                        valor = 8 * contador;
                        break;
                    case '9':
                        valor = 9 * contador;
                        break;
                    case 'A':
                        valor = 10 * contador;
                        break;
                    case 'B':
                        valor = 11 * contador;
                        break;
                    case 'C':
                        valor = 12 * contador;
                        break;
                    case 'D':
                        valor = 13 * contador;
                        break;
                    case 'E':
                        valor = 14 * contador;
                        break;
                    case 'F':
                        valor = 15 * contador;
                        break;
                    case 'G':
                        valor = 16 * contador;
                        break;
                    case 'H':
                        valor = 17 * contador;
                        break;
                    case 'I':
                        valor = 18 * contador;
                        break;
                    case 'J':
                        valor = 19 * contador;
                        break;
                    case 'K':
                        valor = 20 * contador;
                        break;
                    case 'L':
                        valor = 21 * contador;
                        break;
                    case 'M':
                        valor = 22 * contador;
                        break;
                    case 'N':
                        valor = 23 * contador;
                        break;
                    case 'Ñ':
                        valor = 24 * contador;
                        break;
                    case 'O':
                        valor = 25 * contador;
                        break;
                    case 'P':
                        valor = 26 * contador;
                        break;
                    case 'Q':
                        valor = 27 * contador;
                        break;
                    case 'R':
                        valor = 28 * contador;
                        break;
                    case 'S':
                        valor = 29 * contador;
                        break;
                    case 'T':
                        valor = 30 * contador;
                        break;
                    case 'U':
                        valor = 31 * contador;
                        break;
                    case 'V':
                        valor = 32 * contador;
                        break;
                    case 'W':
                        valor = 33 * contador;
                        break;
                    case 'X':
                        valor = 34 * contador;
                        break;
                    case 'Y':
                        valor = 35 * contador;
                        break;
                    case 'Z':
                        valor = 36 * contador;
                        break;
                    default:
                        throw new ArgumentException($"Caracter invalido en la compisicion de la pre CURP. [{caracter}]");
                }

                contador--;
                sumatoria = sumatoria + valor;
            }

            // 12.- 2do digito verificador
            var numVer = sumatoria % 10;
            numVer = 10 - numVer;
            numVer = numVer == 10 ? 0 : numVer;

            return numVer;
        }

        /// <summary>
        ///     Aplica filtros a un texto en base a lo establecido para conformar la CURP.
        /// </summary>
        /// <param name="str">El texto a filtrar.</param>
        /// <returns> El texto resultante.</returns>
        private static string Filtrar(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            // Nombres, paterno y materno en mayuscula
            str = str.ToUpper();

            // Eliminar acentos en vocales
            str = str.RemoveAccentMarks();

            // Eliminar dieresis en vocales
            str = str.RemoveVowelDieresis();

            // Criterios de excepcion
            var palabras = str.Split(' ')
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .ToList();

            // Preposición, conjunción, contraccion
            var arr_1 = new[] { "DA", "DAS", "DE", "DEL", "DER", "DI", "DIE", "DD", "EL", "LA", "LOS", "LAS", "LE", "LES", "MAC", "MC", "VAN", "VON", "Y", "J", "MA" };

            palabras = palabras.Where(i => !arr_1.Contains(i))
                .ToList();

            // Nombre compuesto
            var arr_2 = new[] { "MARIA", "MA.", "MA", "JOSE", "J", "J." };

            if (palabras.Count >= 2 && arr_2.Contains(palabras[0]))
            {
                palabras.RemoveAt(0);
            }

            // Caracteres especiales
            str = palabras[0]
                .Replace('/', 'X')
                .Replace('-', 'X')
                .Replace('.', 'X');

            return str;
        }

        /// <summary>
        ///     Calcula la CURP en base a la información de la persona.
        /// </summary>
        /// <returns> La CURP.</returns>
        private string CalculaCurp()
        {
            // Aplicar filtros
            var nombres = Filtrar(this.Nombres);
            var paterno = Filtrar(this.Paterno);
            var materno = Filtrar(this.Materno);

            // Posicion 1-4
            var uno = paterno[0] == 'Ñ' ? 'X' : paterno[0];
            var dos = paterno.InternalVowel(1) ?? 'X';
            var tres = string.IsNullOrWhiteSpace(materno) ? 'X' : (materno[0] == 'Ñ' ? 'X' : materno[0]);
            var cuatro = nombres[0] == 'Ñ' ? 'X' : nombres[0];

            var fecha = $"{this.FechaNacimiento:yy}{this.FechaNacimiento.Month:D2}{this.FechaNacimiento.Day:D2}";
            var sexo = (char)this.Sexo;
            var estado = this.Estados[this.Estado];

            // Posicion 14-16
            var x = paterno.InternalConsonant(1);
            var y = materno?.InternalConsonant(1);
            var z = nombres.InternalConsonant(1);

            var catorce = x == null ? 'X' : (x == 'Ñ' ? 'X' : x);
            var quince = y == null ? 'X' : (y == 'Ñ' ? 'X' : y);
            var dieciseis = z == null ? 'X' : (z == 'Ñ' ? 'X' : z);

            // Pre CURP
            var preCURP = $"{uno}{dos}{tres}{cuatro}{fecha}{sexo}{estado}{catorce}{quince}{dieciseis}";

            // Reemplaza el 2do caracter por una X donde comience con alguna de las palabras de la lisa de "Palabras Inconvenientes"
            if (this.PalabrasInconvenientes.Contains(preCURP.Substring(0, 4)))
            {
                preCURP = preCURP[0] + "X" + preCURP.Substring(2);
            }

            // Digito diferenciador de homonimia y siglo
            var diferenciador = this.FechaNacimiento.Year < 2000 ? "0" : "A";

            // Digito verificador
            var codigoVerificador = CodigoVerificador(preCURP);

            return $"{preCURP}{diferenciador}{codigoVerificador}";
        }
    }
}
