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
   [XmlRoot(ElementName = "Entrada" )]
   [XmlType(TypeName =  "Entrada" , Namespace = "ObligatorioFinal" )]
   [Serializable]
   public class SdtEntrada : GxSilentTrnSdt
   {
      public SdtEntrada( )
      {
      }

      public SdtEntrada( IGxContext context )
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

      public void Load( short AV11EntradaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV11EntradaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EntradaId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Entrada");
         metadata.Set("BT", "Entrada");
         metadata.Set("PK", "[ \"EntradaId\" ]");
         metadata.Set("PKAssigned", "[ \"EntradaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"EspectaculoId\",\"SectorId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PaisId\" ],\"FKMap\":[ \"PaisCompraId-PaisId\" ] } ]");
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
         state.Add("gxTpr_Entradaid_Z");
         state.Add("gxTpr_Espectaculoid_Z");
         state.Add("gxTpr_Espectaculonombre_Z");
         state.Add("gxTpr_Espectaculofecha_Z_Nullable");
         state.Add("gxTpr_Sectorid_Z");
         state.Add("gxTpr_Sectornombre_Z");
         state.Add("gxTpr_Sectorprecio_Z");
         state.Add("gxTpr_Sectorentradasvendidas_Z");
         state.Add("gxTpr_Sectorentradasdisponibles_Z");
         state.Add("gxTpr_Paiscompraid_Z");
         state.Add("gxTpr_Paiscompranombre_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEntrada sdt;
         sdt = (SdtEntrada)(source);
         gxTv_SdtEntrada_Entradaid = sdt.gxTv_SdtEntrada_Entradaid ;
         gxTv_SdtEntrada_Espectaculoid = sdt.gxTv_SdtEntrada_Espectaculoid ;
         gxTv_SdtEntrada_Espectaculonombre = sdt.gxTv_SdtEntrada_Espectaculonombre ;
         gxTv_SdtEntrada_Espectaculofecha = sdt.gxTv_SdtEntrada_Espectaculofecha ;
         gxTv_SdtEntrada_Sectorid = sdt.gxTv_SdtEntrada_Sectorid ;
         gxTv_SdtEntrada_Sectornombre = sdt.gxTv_SdtEntrada_Sectornombre ;
         gxTv_SdtEntrada_Sectorprecio = sdt.gxTv_SdtEntrada_Sectorprecio ;
         gxTv_SdtEntrada_Sectorentradasvendidas = sdt.gxTv_SdtEntrada_Sectorentradasvendidas ;
         gxTv_SdtEntrada_Sectorentradasdisponibles = sdt.gxTv_SdtEntrada_Sectorentradasdisponibles ;
         gxTv_SdtEntrada_Paiscompraid = sdt.gxTv_SdtEntrada_Paiscompraid ;
         gxTv_SdtEntrada_Paiscompranombre = sdt.gxTv_SdtEntrada_Paiscompranombre ;
         gxTv_SdtEntrada_Mode = sdt.gxTv_SdtEntrada_Mode ;
         gxTv_SdtEntrada_Initialized = sdt.gxTv_SdtEntrada_Initialized ;
         gxTv_SdtEntrada_Entradaid_Z = sdt.gxTv_SdtEntrada_Entradaid_Z ;
         gxTv_SdtEntrada_Espectaculoid_Z = sdt.gxTv_SdtEntrada_Espectaculoid_Z ;
         gxTv_SdtEntrada_Espectaculonombre_Z = sdt.gxTv_SdtEntrada_Espectaculonombre_Z ;
         gxTv_SdtEntrada_Espectaculofecha_Z = sdt.gxTv_SdtEntrada_Espectaculofecha_Z ;
         gxTv_SdtEntrada_Sectorid_Z = sdt.gxTv_SdtEntrada_Sectorid_Z ;
         gxTv_SdtEntrada_Sectornombre_Z = sdt.gxTv_SdtEntrada_Sectornombre_Z ;
         gxTv_SdtEntrada_Sectorprecio_Z = sdt.gxTv_SdtEntrada_Sectorprecio_Z ;
         gxTv_SdtEntrada_Sectorentradasvendidas_Z = sdt.gxTv_SdtEntrada_Sectorentradasvendidas_Z ;
         gxTv_SdtEntrada_Sectorentradasdisponibles_Z = sdt.gxTv_SdtEntrada_Sectorentradasdisponibles_Z ;
         gxTv_SdtEntrada_Paiscompraid_Z = sdt.gxTv_SdtEntrada_Paiscompraid_Z ;
         gxTv_SdtEntrada_Paiscompranombre_Z = sdt.gxTv_SdtEntrada_Paiscompranombre_Z ;
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
         AddObjectProperty("EntradaId", gxTv_SdtEntrada_Entradaid, false, includeNonInitialized);
         AddObjectProperty("EspectaculoId", gxTv_SdtEntrada_Espectaculoid, false, includeNonInitialized);
         AddObjectProperty("EspectaculoNombre", gxTv_SdtEntrada_Espectaculonombre, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEntrada_Espectaculofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEntrada_Espectaculofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEntrada_Espectaculofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("EspectaculoFecha", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SectorId", gxTv_SdtEntrada_Sectorid, false, includeNonInitialized);
         AddObjectProperty("SectorNombre", gxTv_SdtEntrada_Sectornombre, false, includeNonInitialized);
         AddObjectProperty("SectorPrecio", gxTv_SdtEntrada_Sectorprecio, false, includeNonInitialized);
         AddObjectProperty("SectorEntradasVendidas", gxTv_SdtEntrada_Sectorentradasvendidas, false, includeNonInitialized);
         AddObjectProperty("SectorEntradasDisponibles", gxTv_SdtEntrada_Sectorentradasdisponibles, false, includeNonInitialized);
         AddObjectProperty("PaisCompraId", gxTv_SdtEntrada_Paiscompraid, false, includeNonInitialized);
         AddObjectProperty("PaisCompraNombre", gxTv_SdtEntrada_Paiscompranombre, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEntrada_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEntrada_Initialized, false, includeNonInitialized);
            AddObjectProperty("EntradaId_Z", gxTv_SdtEntrada_Entradaid_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoId_Z", gxTv_SdtEntrada_Espectaculoid_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoNombre_Z", gxTv_SdtEntrada_Espectaculonombre_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEntrada_Espectaculofecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEntrada_Espectaculofecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEntrada_Espectaculofecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("EspectaculoFecha_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SectorId_Z", gxTv_SdtEntrada_Sectorid_Z, false, includeNonInitialized);
            AddObjectProperty("SectorNombre_Z", gxTv_SdtEntrada_Sectornombre_Z, false, includeNonInitialized);
            AddObjectProperty("SectorPrecio_Z", gxTv_SdtEntrada_Sectorprecio_Z, false, includeNonInitialized);
            AddObjectProperty("SectorEntradasVendidas_Z", gxTv_SdtEntrada_Sectorentradasvendidas_Z, false, includeNonInitialized);
            AddObjectProperty("SectorEntradasDisponibles_Z", gxTv_SdtEntrada_Sectorentradasdisponibles_Z, false, includeNonInitialized);
            AddObjectProperty("PaisCompraId_Z", gxTv_SdtEntrada_Paiscompraid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisCompraNombre_Z", gxTv_SdtEntrada_Paiscompranombre_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEntrada sdt )
      {
         if ( sdt.IsDirty("EntradaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Entradaid = sdt.gxTv_SdtEntrada_Entradaid ;
         }
         if ( sdt.IsDirty("EspectaculoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Espectaculoid = sdt.gxTv_SdtEntrada_Espectaculoid ;
         }
         if ( sdt.IsDirty("EspectaculoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Espectaculonombre = sdt.gxTv_SdtEntrada_Espectaculonombre ;
         }
         if ( sdt.IsDirty("EspectaculoFecha") )
         {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Espectaculofecha = sdt.gxTv_SdtEntrada_Espectaculofecha ;
         }
         if ( sdt.IsDirty("SectorId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectorid = sdt.gxTv_SdtEntrada_Sectorid ;
         }
         if ( sdt.IsDirty("SectorNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectornombre = sdt.gxTv_SdtEntrada_Sectornombre ;
         }
         if ( sdt.IsDirty("SectorPrecio") )
         {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectorprecio = sdt.gxTv_SdtEntrada_Sectorprecio ;
         }
         if ( sdt.IsDirty("SectorEntradasVendidas") )
         {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectorentradasvendidas = sdt.gxTv_SdtEntrada_Sectorentradasvendidas ;
         }
         if ( sdt.IsDirty("SectorEntradasDisponibles") )
         {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectorentradasdisponibles = sdt.gxTv_SdtEntrada_Sectorentradasdisponibles ;
         }
         if ( sdt.IsDirty("PaisCompraId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Paiscompraid = sdt.gxTv_SdtEntrada_Paiscompraid ;
         }
         if ( sdt.IsDirty("PaisCompraNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Paiscompranombre = sdt.gxTv_SdtEntrada_Paiscompranombre ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EntradaId" )]
      [  XmlElement( ElementName = "EntradaId"   )]
      public short gxTpr_Entradaid
      {
         get {
            return gxTv_SdtEntrada_Entradaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtEntrada_Entradaid != value )
            {
               gxTv_SdtEntrada_Mode = "INS";
               this.gxTv_SdtEntrada_Entradaid_Z_SetNull( );
               this.gxTv_SdtEntrada_Espectaculoid_Z_SetNull( );
               this.gxTv_SdtEntrada_Espectaculonombre_Z_SetNull( );
               this.gxTv_SdtEntrada_Espectaculofecha_Z_SetNull( );
               this.gxTv_SdtEntrada_Sectorid_Z_SetNull( );
               this.gxTv_SdtEntrada_Sectornombre_Z_SetNull( );
               this.gxTv_SdtEntrada_Sectorprecio_Z_SetNull( );
               this.gxTv_SdtEntrada_Sectorentradasvendidas_Z_SetNull( );
               this.gxTv_SdtEntrada_Sectorentradasdisponibles_Z_SetNull( );
               this.gxTv_SdtEntrada_Paiscompraid_Z_SetNull( );
               this.gxTv_SdtEntrada_Paiscompranombre_Z_SetNull( );
            }
            gxTv_SdtEntrada_Entradaid = value;
            SetDirty("Entradaid");
         }

      }

      [  SoapElement( ElementName = "EspectaculoId" )]
      [  XmlElement( ElementName = "EspectaculoId"   )]
      public short gxTpr_Espectaculoid
      {
         get {
            return gxTv_SdtEntrada_Espectaculoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Espectaculoid = value;
            SetDirty("Espectaculoid");
         }

      }

      [  SoapElement( ElementName = "EspectaculoNombre" )]
      [  XmlElement( ElementName = "EspectaculoNombre"   )]
      public string gxTpr_Espectaculonombre
      {
         get {
            return gxTv_SdtEntrada_Espectaculonombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Espectaculonombre = value;
            SetDirty("Espectaculonombre");
         }

      }

      [  SoapElement( ElementName = "EspectaculoFecha" )]
      [  XmlElement( ElementName = "EspectaculoFecha"  , IsNullable=true )]
      public string gxTpr_Espectaculofecha_Nullable
      {
         get {
            if ( gxTv_SdtEntrada_Espectaculofecha == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEntrada_Espectaculofecha).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEntrada_Espectaculofecha = DateTime.MinValue;
            else
               gxTv_SdtEntrada_Espectaculofecha = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Espectaculofecha
      {
         get {
            return gxTv_SdtEntrada_Espectaculofecha ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Espectaculofecha = value;
            SetDirty("Espectaculofecha");
         }

      }

      [  SoapElement( ElementName = "SectorId" )]
      [  XmlElement( ElementName = "SectorId"   )]
      public short gxTpr_Sectorid
      {
         get {
            return gxTv_SdtEntrada_Sectorid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectorid = value;
            SetDirty("Sectorid");
         }

      }

      [  SoapElement( ElementName = "SectorNombre" )]
      [  XmlElement( ElementName = "SectorNombre"   )]
      public string gxTpr_Sectornombre
      {
         get {
            return gxTv_SdtEntrada_Sectornombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectornombre = value;
            SetDirty("Sectornombre");
         }

      }

      [  SoapElement( ElementName = "SectorPrecio" )]
      [  XmlElement( ElementName = "SectorPrecio"   )]
      public int gxTpr_Sectorprecio
      {
         get {
            return gxTv_SdtEntrada_Sectorprecio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectorprecio = value;
            SetDirty("Sectorprecio");
         }

      }

      [  SoapElement( ElementName = "SectorEntradasVendidas" )]
      [  XmlElement( ElementName = "SectorEntradasVendidas"   )]
      public int gxTpr_Sectorentradasvendidas
      {
         get {
            return gxTv_SdtEntrada_Sectorentradasvendidas ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectorentradasvendidas = value;
            SetDirty("Sectorentradasvendidas");
         }

      }

      public void gxTv_SdtEntrada_Sectorentradasvendidas_SetNull( )
      {
         gxTv_SdtEntrada_Sectorentradasvendidas = 0;
         SetDirty("Sectorentradasvendidas");
         return  ;
      }

      public bool gxTv_SdtEntrada_Sectorentradasvendidas_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorEntradasDisponibles" )]
      [  XmlElement( ElementName = "SectorEntradasDisponibles"   )]
      public int gxTpr_Sectorentradasdisponibles
      {
         get {
            return gxTv_SdtEntrada_Sectorentradasdisponibles ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectorentradasdisponibles = value;
            SetDirty("Sectorentradasdisponibles");
         }

      }

      public void gxTv_SdtEntrada_Sectorentradasdisponibles_SetNull( )
      {
         gxTv_SdtEntrada_Sectorentradasdisponibles = 0;
         SetDirty("Sectorentradasdisponibles");
         return  ;
      }

      public bool gxTv_SdtEntrada_Sectorentradasdisponibles_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisCompraId" )]
      [  XmlElement( ElementName = "PaisCompraId"   )]
      public short gxTpr_Paiscompraid
      {
         get {
            return gxTv_SdtEntrada_Paiscompraid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Paiscompraid = value;
            SetDirty("Paiscompraid");
         }

      }

      [  SoapElement( ElementName = "PaisCompraNombre" )]
      [  XmlElement( ElementName = "PaisCompraNombre"   )]
      public string gxTpr_Paiscompranombre
      {
         get {
            return gxTv_SdtEntrada_Paiscompranombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Paiscompranombre = value;
            SetDirty("Paiscompranombre");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEntrada_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEntrada_Mode_SetNull( )
      {
         gxTv_SdtEntrada_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEntrada_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEntrada_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEntrada_Initialized_SetNull( )
      {
         gxTv_SdtEntrada_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEntrada_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EntradaId_Z" )]
      [  XmlElement( ElementName = "EntradaId_Z"   )]
      public short gxTpr_Entradaid_Z
      {
         get {
            return gxTv_SdtEntrada_Entradaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Entradaid_Z = value;
            SetDirty("Entradaid_Z");
         }

      }

      public void gxTv_SdtEntrada_Entradaid_Z_SetNull( )
      {
         gxTv_SdtEntrada_Entradaid_Z = 0;
         SetDirty("Entradaid_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Entradaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoId_Z" )]
      [  XmlElement( ElementName = "EspectaculoId_Z"   )]
      public short gxTpr_Espectaculoid_Z
      {
         get {
            return gxTv_SdtEntrada_Espectaculoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Espectaculoid_Z = value;
            SetDirty("Espectaculoid_Z");
         }

      }

      public void gxTv_SdtEntrada_Espectaculoid_Z_SetNull( )
      {
         gxTv_SdtEntrada_Espectaculoid_Z = 0;
         SetDirty("Espectaculoid_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Espectaculoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoNombre_Z" )]
      [  XmlElement( ElementName = "EspectaculoNombre_Z"   )]
      public string gxTpr_Espectaculonombre_Z
      {
         get {
            return gxTv_SdtEntrada_Espectaculonombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Espectaculonombre_Z = value;
            SetDirty("Espectaculonombre_Z");
         }

      }

      public void gxTv_SdtEntrada_Espectaculonombre_Z_SetNull( )
      {
         gxTv_SdtEntrada_Espectaculonombre_Z = "";
         SetDirty("Espectaculonombre_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Espectaculonombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoFecha_Z" )]
      [  XmlElement( ElementName = "EspectaculoFecha_Z"  , IsNullable=true )]
      public string gxTpr_Espectaculofecha_Z_Nullable
      {
         get {
            if ( gxTv_SdtEntrada_Espectaculofecha_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEntrada_Espectaculofecha_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEntrada_Espectaculofecha_Z = DateTime.MinValue;
            else
               gxTv_SdtEntrada_Espectaculofecha_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Espectaculofecha_Z
      {
         get {
            return gxTv_SdtEntrada_Espectaculofecha_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Espectaculofecha_Z = value;
            SetDirty("Espectaculofecha_Z");
         }

      }

      public void gxTv_SdtEntrada_Espectaculofecha_Z_SetNull( )
      {
         gxTv_SdtEntrada_Espectaculofecha_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Espectaculofecha_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Espectaculofecha_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorId_Z" )]
      [  XmlElement( ElementName = "SectorId_Z"   )]
      public short gxTpr_Sectorid_Z
      {
         get {
            return gxTv_SdtEntrada_Sectorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectorid_Z = value;
            SetDirty("Sectorid_Z");
         }

      }

      public void gxTv_SdtEntrada_Sectorid_Z_SetNull( )
      {
         gxTv_SdtEntrada_Sectorid_Z = 0;
         SetDirty("Sectorid_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Sectorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorNombre_Z" )]
      [  XmlElement( ElementName = "SectorNombre_Z"   )]
      public string gxTpr_Sectornombre_Z
      {
         get {
            return gxTv_SdtEntrada_Sectornombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectornombre_Z = value;
            SetDirty("Sectornombre_Z");
         }

      }

      public void gxTv_SdtEntrada_Sectornombre_Z_SetNull( )
      {
         gxTv_SdtEntrada_Sectornombre_Z = "";
         SetDirty("Sectornombre_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Sectornombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorPrecio_Z" )]
      [  XmlElement( ElementName = "SectorPrecio_Z"   )]
      public int gxTpr_Sectorprecio_Z
      {
         get {
            return gxTv_SdtEntrada_Sectorprecio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectorprecio_Z = value;
            SetDirty("Sectorprecio_Z");
         }

      }

      public void gxTv_SdtEntrada_Sectorprecio_Z_SetNull( )
      {
         gxTv_SdtEntrada_Sectorprecio_Z = 0;
         SetDirty("Sectorprecio_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Sectorprecio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorEntradasVendidas_Z" )]
      [  XmlElement( ElementName = "SectorEntradasVendidas_Z"   )]
      public int gxTpr_Sectorentradasvendidas_Z
      {
         get {
            return gxTv_SdtEntrada_Sectorentradasvendidas_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectorentradasvendidas_Z = value;
            SetDirty("Sectorentradasvendidas_Z");
         }

      }

      public void gxTv_SdtEntrada_Sectorentradasvendidas_Z_SetNull( )
      {
         gxTv_SdtEntrada_Sectorentradasvendidas_Z = 0;
         SetDirty("Sectorentradasvendidas_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Sectorentradasvendidas_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorEntradasDisponibles_Z" )]
      [  XmlElement( ElementName = "SectorEntradasDisponibles_Z"   )]
      public int gxTpr_Sectorentradasdisponibles_Z
      {
         get {
            return gxTv_SdtEntrada_Sectorentradasdisponibles_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Sectorentradasdisponibles_Z = value;
            SetDirty("Sectorentradasdisponibles_Z");
         }

      }

      public void gxTv_SdtEntrada_Sectorentradasdisponibles_Z_SetNull( )
      {
         gxTv_SdtEntrada_Sectorentradasdisponibles_Z = 0;
         SetDirty("Sectorentradasdisponibles_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Sectorentradasdisponibles_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisCompraId_Z" )]
      [  XmlElement( ElementName = "PaisCompraId_Z"   )]
      public short gxTpr_Paiscompraid_Z
      {
         get {
            return gxTv_SdtEntrada_Paiscompraid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Paiscompraid_Z = value;
            SetDirty("Paiscompraid_Z");
         }

      }

      public void gxTv_SdtEntrada_Paiscompraid_Z_SetNull( )
      {
         gxTv_SdtEntrada_Paiscompraid_Z = 0;
         SetDirty("Paiscompraid_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Paiscompraid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisCompraNombre_Z" )]
      [  XmlElement( ElementName = "PaisCompraNombre_Z"   )]
      public string gxTpr_Paiscompranombre_Z
      {
         get {
            return gxTv_SdtEntrada_Paiscompranombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEntrada_Paiscompranombre_Z = value;
            SetDirty("Paiscompranombre_Z");
         }

      }

      public void gxTv_SdtEntrada_Paiscompranombre_Z_SetNull( )
      {
         gxTv_SdtEntrada_Paiscompranombre_Z = "";
         SetDirty("Paiscompranombre_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Paiscompranombre_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtEntrada_Espectaculonombre = "";
         gxTv_SdtEntrada_Espectaculofecha = DateTime.MinValue;
         gxTv_SdtEntrada_Sectornombre = "";
         gxTv_SdtEntrada_Paiscompranombre = "";
         gxTv_SdtEntrada_Mode = "";
         gxTv_SdtEntrada_Espectaculonombre_Z = "";
         gxTv_SdtEntrada_Espectaculofecha_Z = DateTime.MinValue;
         gxTv_SdtEntrada_Sectornombre_Z = "";
         gxTv_SdtEntrada_Paiscompranombre_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "entrada", "GeneXus.Programs.entrada_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtEntrada_Entradaid ;
      private short sdtIsNull ;
      private short gxTv_SdtEntrada_Espectaculoid ;
      private short gxTv_SdtEntrada_Sectorid ;
      private short gxTv_SdtEntrada_Paiscompraid ;
      private short gxTv_SdtEntrada_Initialized ;
      private short gxTv_SdtEntrada_Entradaid_Z ;
      private short gxTv_SdtEntrada_Espectaculoid_Z ;
      private short gxTv_SdtEntrada_Sectorid_Z ;
      private short gxTv_SdtEntrada_Paiscompraid_Z ;
      private int gxTv_SdtEntrada_Sectorprecio ;
      private int gxTv_SdtEntrada_Sectorentradasvendidas ;
      private int gxTv_SdtEntrada_Sectorentradasdisponibles ;
      private int gxTv_SdtEntrada_Sectorprecio_Z ;
      private int gxTv_SdtEntrada_Sectorentradasvendidas_Z ;
      private int gxTv_SdtEntrada_Sectorentradasdisponibles_Z ;
      private string gxTv_SdtEntrada_Espectaculonombre ;
      private string gxTv_SdtEntrada_Sectornombre ;
      private string gxTv_SdtEntrada_Paiscompranombre ;
      private string gxTv_SdtEntrada_Mode ;
      private string gxTv_SdtEntrada_Espectaculonombre_Z ;
      private string gxTv_SdtEntrada_Sectornombre_Z ;
      private string gxTv_SdtEntrada_Paiscompranombre_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtEntrada_Espectaculofecha ;
      private DateTime gxTv_SdtEntrada_Espectaculofecha_Z ;
   }

   [DataContract(Name = @"Entrada", Namespace = "ObligatorioFinal")]
   public class SdtEntrada_RESTInterface : GxGenericCollectionItem<SdtEntrada>
   {
      public SdtEntrada_RESTInterface( ) : base()
      {
      }

      public SdtEntrada_RESTInterface( SdtEntrada psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EntradaId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Entradaid
      {
         get {
            return sdt.gxTpr_Entradaid ;
         }

         set {
            sdt.gxTpr_Entradaid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EspectaculoId" , Order = 1 )]
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

      [DataMember( Name = "EspectaculoNombre" , Order = 2 )]
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

      [DataMember( Name = "EspectaculoFecha" , Order = 3 )]
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

      [DataMember( Name = "SectorId" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sectorid
      {
         get {
            return sdt.gxTpr_Sectorid ;
         }

         set {
            sdt.gxTpr_Sectorid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SectorNombre" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Sectornombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Sectornombre) ;
         }

         set {
            sdt.gxTpr_Sectornombre = value;
         }

      }

      [DataMember( Name = "SectorPrecio" , Order = 6 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Sectorprecio
      {
         get {
            return sdt.gxTpr_Sectorprecio ;
         }

         set {
            sdt.gxTpr_Sectorprecio = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SectorEntradasVendidas" , Order = 7 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Sectorentradasvendidas
      {
         get {
            return sdt.gxTpr_Sectorentradasvendidas ;
         }

         set {
            sdt.gxTpr_Sectorentradasvendidas = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SectorEntradasDisponibles" , Order = 8 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Sectorentradasdisponibles
      {
         get {
            return sdt.gxTpr_Sectorentradasdisponibles ;
         }

         set {
            sdt.gxTpr_Sectorentradasdisponibles = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PaisCompraId" , Order = 9 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Paiscompraid
      {
         get {
            return sdt.gxTpr_Paiscompraid ;
         }

         set {
            sdt.gxTpr_Paiscompraid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PaisCompraNombre" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Paiscompranombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Paiscompranombre) ;
         }

         set {
            sdt.gxTpr_Paiscompranombre = value;
         }

      }

      public SdtEntrada sdt
      {
         get {
            return (SdtEntrada)Sdt ;
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
            sdt = new SdtEntrada() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 11 )]
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

   [DataContract(Name = @"Entrada", Namespace = "ObligatorioFinal")]
   public class SdtEntrada_RESTLInterface : GxGenericCollectionItem<SdtEntrada>
   {
      public SdtEntrada_RESTLInterface( ) : base()
      {
      }

      public SdtEntrada_RESTLInterface( SdtEntrada psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PaisCompraNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Paiscompranombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Paiscompranombre) ;
         }

         set {
            sdt.gxTpr_Paiscompranombre = value;
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

      public SdtEntrada sdt
      {
         get {
            return (SdtEntrada)Sdt ;
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
            sdt = new SdtEntrada() ;
         }
      }

   }

}
