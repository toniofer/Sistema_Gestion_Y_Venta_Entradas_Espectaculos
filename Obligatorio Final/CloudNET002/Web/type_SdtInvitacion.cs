using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Invitacion" )]
   [XmlType(TypeName =  "Invitacion" , Namespace = "ObligatorioFinal" )]
   [Serializable]
   public class SdtInvitacion : GxSilentTrnSdt
   {
      public SdtInvitacion( )
      {
      }

      public SdtInvitacion( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( short AV17InvitacionId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV17InvitacionId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"InvitacionId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Invitacion");
         metadata.Set("BT", "Invitacion");
         metadata.Set("PK", "[ \"InvitacionId\" ]");
         metadata.Set("PKAssigned", "[ \"InvitacionId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"EspectaculoId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Invitacionid_Z");
         state.Add("gxTpr_Invitacionnombreinvitado_Z");
         state.Add("gxTpr_Espectaculoid_Z");
         state.Add("gxTpr_Espectaculonombre_Z");
         state.Add("gxTpr_Espectaculofecha_Z_Nullable");
         state.Add("gxTpr_Espectaculoinvitacionesentregadas_Z");
         state.Add("gxTpr_Espectaculoinvitacionesdisponibles_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtInvitacion sdt;
         sdt = (SdtInvitacion)(source);
         gxTv_SdtInvitacion_Invitacionid = sdt.gxTv_SdtInvitacion_Invitacionid ;
         gxTv_SdtInvitacion_Invitacionnombreinvitado = sdt.gxTv_SdtInvitacion_Invitacionnombreinvitado ;
         gxTv_SdtInvitacion_Espectaculoid = sdt.gxTv_SdtInvitacion_Espectaculoid ;
         gxTv_SdtInvitacion_Espectaculonombre = sdt.gxTv_SdtInvitacion_Espectaculonombre ;
         gxTv_SdtInvitacion_Espectaculofecha = sdt.gxTv_SdtInvitacion_Espectaculofecha ;
         gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas = sdt.gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas ;
         gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles = sdt.gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles ;
         gxTv_SdtInvitacion_Mode = sdt.gxTv_SdtInvitacion_Mode ;
         gxTv_SdtInvitacion_Initialized = sdt.gxTv_SdtInvitacion_Initialized ;
         gxTv_SdtInvitacion_Invitacionid_Z = sdt.gxTv_SdtInvitacion_Invitacionid_Z ;
         gxTv_SdtInvitacion_Invitacionnombreinvitado_Z = sdt.gxTv_SdtInvitacion_Invitacionnombreinvitado_Z ;
         gxTv_SdtInvitacion_Espectaculoid_Z = sdt.gxTv_SdtInvitacion_Espectaculoid_Z ;
         gxTv_SdtInvitacion_Espectaculonombre_Z = sdt.gxTv_SdtInvitacion_Espectaculonombre_Z ;
         gxTv_SdtInvitacion_Espectaculofecha_Z = sdt.gxTv_SdtInvitacion_Espectaculofecha_Z ;
         gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas_Z = sdt.gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas_Z ;
         gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles_Z = sdt.gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles_Z ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("InvitacionId", gxTv_SdtInvitacion_Invitacionid, false, includeNonInitialized);
         AddObjectProperty("InvitacionNombreInvitado", gxTv_SdtInvitacion_Invitacionnombreinvitado, false, includeNonInitialized);
         AddObjectProperty("EspectaculoId", gxTv_SdtInvitacion_Espectaculoid, false, includeNonInitialized);
         AddObjectProperty("EspectaculoNombre", gxTv_SdtInvitacion_Espectaculonombre, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtInvitacion_Espectaculofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtInvitacion_Espectaculofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtInvitacion_Espectaculofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("EspectaculoFecha", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("EspectaculoInvitacionesEntregadas", gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas, false, includeNonInitialized);
         AddObjectProperty("EspectaculoInvitacionesDisponibles", gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtInvitacion_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtInvitacion_Initialized, false, includeNonInitialized);
            AddObjectProperty("InvitacionId_Z", gxTv_SdtInvitacion_Invitacionid_Z, false, includeNonInitialized);
            AddObjectProperty("InvitacionNombreInvitado_Z", gxTv_SdtInvitacion_Invitacionnombreinvitado_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoId_Z", gxTv_SdtInvitacion_Espectaculoid_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoNombre_Z", gxTv_SdtInvitacion_Espectaculonombre_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtInvitacion_Espectaculofecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtInvitacion_Espectaculofecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtInvitacion_Espectaculofecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("EspectaculoFecha_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("EspectaculoInvitacionesEntregadas_Z", gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoInvitacionesDisponibles_Z", gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtInvitacion sdt )
      {
         if ( sdt.IsDirty("InvitacionId") )
         {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Invitacionid = sdt.gxTv_SdtInvitacion_Invitacionid ;
         }
         if ( sdt.IsDirty("InvitacionNombreInvitado") )
         {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Invitacionnombreinvitado = sdt.gxTv_SdtInvitacion_Invitacionnombreinvitado ;
         }
         if ( sdt.IsDirty("EspectaculoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculoid = sdt.gxTv_SdtInvitacion_Espectaculoid ;
         }
         if ( sdt.IsDirty("EspectaculoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculonombre = sdt.gxTv_SdtInvitacion_Espectaculonombre ;
         }
         if ( sdt.IsDirty("EspectaculoFecha") )
         {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculofecha = sdt.gxTv_SdtInvitacion_Espectaculofecha ;
         }
         if ( sdt.IsDirty("EspectaculoInvitacionesEntregadas") )
         {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas = sdt.gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas ;
         }
         if ( sdt.IsDirty("EspectaculoInvitacionesDisponibles") )
         {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles = sdt.gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "InvitacionId" )]
      [  XmlElement( ElementName = "InvitacionId"   )]
      public short gxTpr_Invitacionid
      {
         get {
            return gxTv_SdtInvitacion_Invitacionid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtInvitacion_Invitacionid != value )
            {
               gxTv_SdtInvitacion_Mode = "INS";
               this.gxTv_SdtInvitacion_Invitacionid_Z_SetNull( );
               this.gxTv_SdtInvitacion_Invitacionnombreinvitado_Z_SetNull( );
               this.gxTv_SdtInvitacion_Espectaculoid_Z_SetNull( );
               this.gxTv_SdtInvitacion_Espectaculonombre_Z_SetNull( );
               this.gxTv_SdtInvitacion_Espectaculofecha_Z_SetNull( );
               this.gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas_Z_SetNull( );
               this.gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles_Z_SetNull( );
            }
            gxTv_SdtInvitacion_Invitacionid = value;
            SetDirty("Invitacionid");
         }

      }

      [  SoapElement( ElementName = "InvitacionNombreInvitado" )]
      [  XmlElement( ElementName = "InvitacionNombreInvitado"   )]
      public string gxTpr_Invitacionnombreinvitado
      {
         get {
            return gxTv_SdtInvitacion_Invitacionnombreinvitado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Invitacionnombreinvitado = value;
            SetDirty("Invitacionnombreinvitado");
         }

      }

      [  SoapElement( ElementName = "EspectaculoId" )]
      [  XmlElement( ElementName = "EspectaculoId"   )]
      public short gxTpr_Espectaculoid
      {
         get {
            return gxTv_SdtInvitacion_Espectaculoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculoid = value;
            SetDirty("Espectaculoid");
         }

      }

      [  SoapElement( ElementName = "EspectaculoNombre" )]
      [  XmlElement( ElementName = "EspectaculoNombre"   )]
      public string gxTpr_Espectaculonombre
      {
         get {
            return gxTv_SdtInvitacion_Espectaculonombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculonombre = value;
            SetDirty("Espectaculonombre");
         }

      }

      [  SoapElement( ElementName = "EspectaculoFecha" )]
      [  XmlElement( ElementName = "EspectaculoFecha"  , IsNullable=true )]
      public string gxTpr_Espectaculofecha_Nullable
      {
         get {
            if ( gxTv_SdtInvitacion_Espectaculofecha == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtInvitacion_Espectaculofecha).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtInvitacion_Espectaculofecha = DateTime.MinValue;
            else
               gxTv_SdtInvitacion_Espectaculofecha = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Espectaculofecha
      {
         get {
            return gxTv_SdtInvitacion_Espectaculofecha ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculofecha = value;
            SetDirty("Espectaculofecha");
         }

      }

      [  SoapElement( ElementName = "EspectaculoInvitacionesEntregadas" )]
      [  XmlElement( ElementName = "EspectaculoInvitacionesEntregadas"   )]
      public short gxTpr_Espectaculoinvitacionesentregadas
      {
         get {
            return gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas = value;
            SetDirty("Espectaculoinvitacionesentregadas");
         }

      }

      [  SoapElement( ElementName = "EspectaculoInvitacionesDisponibles" )]
      [  XmlElement( ElementName = "EspectaculoInvitacionesDisponibles"   )]
      public short gxTpr_Espectaculoinvitacionesdisponibles
      {
         get {
            return gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles = value;
            SetDirty("Espectaculoinvitacionesdisponibles");
         }

      }

      public void gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles_SetNull( )
      {
         gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles = 0;
         SetDirty("Espectaculoinvitacionesdisponibles");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtInvitacion_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtInvitacion_Mode_SetNull( )
      {
         gxTv_SdtInvitacion_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtInvitacion_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtInvitacion_Initialized_SetNull( )
      {
         gxTv_SdtInvitacion_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvitacionId_Z" )]
      [  XmlElement( ElementName = "InvitacionId_Z"   )]
      public short gxTpr_Invitacionid_Z
      {
         get {
            return gxTv_SdtInvitacion_Invitacionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Invitacionid_Z = value;
            SetDirty("Invitacionid_Z");
         }

      }

      public void gxTv_SdtInvitacion_Invitacionid_Z_SetNull( )
      {
         gxTv_SdtInvitacion_Invitacionid_Z = 0;
         SetDirty("Invitacionid_Z");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Invitacionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvitacionNombreInvitado_Z" )]
      [  XmlElement( ElementName = "InvitacionNombreInvitado_Z"   )]
      public string gxTpr_Invitacionnombreinvitado_Z
      {
         get {
            return gxTv_SdtInvitacion_Invitacionnombreinvitado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Invitacionnombreinvitado_Z = value;
            SetDirty("Invitacionnombreinvitado_Z");
         }

      }

      public void gxTv_SdtInvitacion_Invitacionnombreinvitado_Z_SetNull( )
      {
         gxTv_SdtInvitacion_Invitacionnombreinvitado_Z = "";
         SetDirty("Invitacionnombreinvitado_Z");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Invitacionnombreinvitado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoId_Z" )]
      [  XmlElement( ElementName = "EspectaculoId_Z"   )]
      public short gxTpr_Espectaculoid_Z
      {
         get {
            return gxTv_SdtInvitacion_Espectaculoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculoid_Z = value;
            SetDirty("Espectaculoid_Z");
         }

      }

      public void gxTv_SdtInvitacion_Espectaculoid_Z_SetNull( )
      {
         gxTv_SdtInvitacion_Espectaculoid_Z = 0;
         SetDirty("Espectaculoid_Z");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Espectaculoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoNombre_Z" )]
      [  XmlElement( ElementName = "EspectaculoNombre_Z"   )]
      public string gxTpr_Espectaculonombre_Z
      {
         get {
            return gxTv_SdtInvitacion_Espectaculonombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculonombre_Z = value;
            SetDirty("Espectaculonombre_Z");
         }

      }

      public void gxTv_SdtInvitacion_Espectaculonombre_Z_SetNull( )
      {
         gxTv_SdtInvitacion_Espectaculonombre_Z = "";
         SetDirty("Espectaculonombre_Z");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Espectaculonombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoFecha_Z" )]
      [  XmlElement( ElementName = "EspectaculoFecha_Z"  , IsNullable=true )]
      public string gxTpr_Espectaculofecha_Z_Nullable
      {
         get {
            if ( gxTv_SdtInvitacion_Espectaculofecha_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtInvitacion_Espectaculofecha_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtInvitacion_Espectaculofecha_Z = DateTime.MinValue;
            else
               gxTv_SdtInvitacion_Espectaculofecha_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Espectaculofecha_Z
      {
         get {
            return gxTv_SdtInvitacion_Espectaculofecha_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculofecha_Z = value;
            SetDirty("Espectaculofecha_Z");
         }

      }

      public void gxTv_SdtInvitacion_Espectaculofecha_Z_SetNull( )
      {
         gxTv_SdtInvitacion_Espectaculofecha_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Espectaculofecha_Z");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Espectaculofecha_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoInvitacionesEntregadas_Z" )]
      [  XmlElement( ElementName = "EspectaculoInvitacionesEntregadas_Z"   )]
      public short gxTpr_Espectaculoinvitacionesentregadas_Z
      {
         get {
            return gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas_Z = value;
            SetDirty("Espectaculoinvitacionesentregadas_Z");
         }

      }

      public void gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas_Z_SetNull( )
      {
         gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas_Z = 0;
         SetDirty("Espectaculoinvitacionesentregadas_Z");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoInvitacionesDisponibles_Z" )]
      [  XmlElement( ElementName = "EspectaculoInvitacionesDisponibles_Z"   )]
      public short gxTpr_Espectaculoinvitacionesdisponibles_Z
      {
         get {
            return gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles_Z = value;
            SetDirty("Espectaculoinvitacionesdisponibles_Z");
         }

      }

      public void gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles_Z_SetNull( )
      {
         gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles_Z = 0;
         SetDirty("Espectaculoinvitacionesdisponibles_Z");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtInvitacion_Invitacionnombreinvitado = "";
         gxTv_SdtInvitacion_Espectaculonombre = "";
         gxTv_SdtInvitacion_Espectaculofecha = DateTime.MinValue;
         gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas = 0;
         gxTv_SdtInvitacion_Mode = "";
         gxTv_SdtInvitacion_Invitacionnombreinvitado_Z = "";
         gxTv_SdtInvitacion_Espectaculonombre_Z = "";
         gxTv_SdtInvitacion_Espectaculofecha_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "invitacion", "GeneXus.Programs.invitacion_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtInvitacion_Invitacionid ;
      private short sdtIsNull ;
      private short gxTv_SdtInvitacion_Espectaculoid ;
      private short gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas ;
      private short gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles ;
      private short gxTv_SdtInvitacion_Initialized ;
      private short gxTv_SdtInvitacion_Invitacionid_Z ;
      private short gxTv_SdtInvitacion_Espectaculoid_Z ;
      private short gxTv_SdtInvitacion_Espectaculoinvitacionesentregadas_Z ;
      private short gxTv_SdtInvitacion_Espectaculoinvitacionesdisponibles_Z ;
      private string gxTv_SdtInvitacion_Invitacionnombreinvitado ;
      private string gxTv_SdtInvitacion_Espectaculonombre ;
      private string gxTv_SdtInvitacion_Mode ;
      private string gxTv_SdtInvitacion_Invitacionnombreinvitado_Z ;
      private string gxTv_SdtInvitacion_Espectaculonombre_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtInvitacion_Espectaculofecha ;
      private DateTime gxTv_SdtInvitacion_Espectaculofecha_Z ;
   }

   [DataContract(Name = @"Invitacion", Namespace = "ObligatorioFinal")]
   public class SdtInvitacion_RESTInterface : GxGenericCollectionItem<SdtInvitacion>
   {
      public SdtInvitacion_RESTInterface( ) : base()
      {
      }

      public SdtInvitacion_RESTInterface( SdtInvitacion psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "InvitacionId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Invitacionid
      {
         get {
            return sdt.gxTpr_Invitacionid ;
         }

         set {
            sdt.gxTpr_Invitacionid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "InvitacionNombreInvitado" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Invitacionnombreinvitado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Invitacionnombreinvitado) ;
         }

         set {
            sdt.gxTpr_Invitacionnombreinvitado = value;
         }

      }

      [DataMember( Name = "EspectaculoId" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Espectaculoid
      {
         get {
            return sdt.gxTpr_Espectaculoid ;
         }

         set {
            sdt.gxTpr_Espectaculoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EspectaculoNombre" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Espectaculonombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Espectaculonombre) ;
         }

         set {
            sdt.gxTpr_Espectaculonombre = value;
         }

      }

      [DataMember( Name = "EspectaculoFecha" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Espectaculofecha
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Espectaculofecha) ;
         }

         set {
            sdt.gxTpr_Espectaculofecha = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "EspectaculoInvitacionesEntregadas" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Espectaculoinvitacionesentregadas
      {
         get {
            return sdt.gxTpr_Espectaculoinvitacionesentregadas ;
         }

         set {
            sdt.gxTpr_Espectaculoinvitacionesentregadas = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EspectaculoInvitacionesDisponibles" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Espectaculoinvitacionesdisponibles
      {
         get {
            return sdt.gxTpr_Espectaculoinvitacionesdisponibles ;
         }

         set {
            sdt.gxTpr_Espectaculoinvitacionesdisponibles = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtInvitacion sdt
      {
         get {
            return (SdtInvitacion)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtInvitacion() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 7 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Invitacion", Namespace = "ObligatorioFinal")]
   public class SdtInvitacion_RESTLInterface : GxGenericCollectionItem<SdtInvitacion>
   {
      public SdtInvitacion_RESTLInterface( ) : base()
      {
      }

      public SdtInvitacion_RESTLInterface( SdtInvitacion psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "InvitacionNombreInvitado" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Invitacionnombreinvitado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Invitacionnombreinvitado) ;
         }

         set {
            sdt.gxTpr_Invitacionnombreinvitado = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtInvitacion sdt
      {
         get {
            return (SdtInvitacion)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtInvitacion() ;
         }
      }

   }

}
