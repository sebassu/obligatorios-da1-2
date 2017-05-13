﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Persistence {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Persistence.ErrorMessages", typeof(ErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No es posible instanciar un repositorio genérico..
        /// </summary>
        internal static string CannotInstantiateRepository {
            get {
                return ResourceManager.GetString("CannotInstantiateRepository", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No es posible eliminar a todos los administradores del sistema; quedaría inutilizable..
        /// </summary>
        internal static string CannotRemoveAllAdministrators {
            get {
                return ResourceManager.GetString("CannotRemoveAllAdministrators", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El elemento que se intenta registrar ya existe en el sistema..
        /// </summary>
        internal static string ElementAlreadyExists {
            get {
                return ResourceManager.GetString("ElementAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Elemento inválido recibido: no se encuentra registrado en el sistema..
        /// </summary>
        internal static string ElementDoesNotExist {
            get {
                return ResourceManager.GetString("ElementDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Los datos de inicio de sesión ingresados no están asociados a ningún usuario, reintente..
        /// </summary>
        internal static string EmailPasswordMismatch {
            get {
                return ResourceManager.GetString("EmailPasswordMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El usuario actual no tiene los permisos de administración requeridos para completar esta acción..
        /// </summary>
        internal static string NoAdministrationPrivileges {
            get {
                return ResourceManager.GetString("NoAdministrationPrivileges", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ya existe una sesión activa en el sistema..
        /// </summary>
        internal static string SessionAlreadyStarted {
            get {
                return ResourceManager.GetString("SessionAlreadyStarted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operación inválida: no se ha iniciado sesión en el sistema aún..
        /// </summary>
        internal static string SessionNotStarted {
            get {
                return ResourceManager.GetString("SessionNotStarted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No es posible que existan en el sistema dos equipos distintos con el mismo nombre..
        /// </summary>
        internal static string TeamNameMustBeUnique {
            get {
                return ResourceManager.GetString("TeamNameMustBeUnique", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No es posible modificar a un pizarrón sin ser miembro del equipo asociado al mismo..
        /// </summary>
        internal static string UserCannotModifyWhiteboard {
            get {
                return ResourceManager.GetString("UserCannotModifyWhiteboard", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Es necesario ser el creador del pizarrón o un administrador del sistema para eliminarlo..
        /// </summary>
        internal static string UserCannotRemoveWhiteboard {
            get {
                return ResourceManager.GetString("UserCannotRemoveWhiteboard", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No es posible tener dos usuarios registrados con la misma dirección de correo electrónico..
        /// </summary>
        internal static string UserEmailMustBeUnique {
            get {
                return ResourceManager.GetString("UserEmailMustBeUnique", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El equipo &quot;{0}&quot; ya posee un pizarrón con el nombre &quot;{1}&quot;..
        /// </summary>
        internal static string WhiteboardNameTeamMustBeUnique {
            get {
                return ResourceManager.GetString("WhiteboardNameTeamMustBeUnique", resourceCulture);
            }
        }
    }
}
