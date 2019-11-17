using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValAlerte.Tools
{
    public class ErrorMessages
    {
        internal static string Disconnect()
        {
            return "Vous avez été déconnecté après un temps d'inactivité trop important.";
        }

        internal static string MissMail()
        {
            return "Merci de saisir votre adresse Mail.";
        }

        internal static string MissMdp()
        {
            return "Merci de saisir votre Mot de Passe.";
        }

        internal static string InvalidMail()
        {
            return "Cette adresse mail n'est pas valide.";
        }

        internal static string FailedLogin()
        {
            return "Il n'y a pas d'utilisateur avec cette adresse mail / mot de passe.";
        }
    }
}
