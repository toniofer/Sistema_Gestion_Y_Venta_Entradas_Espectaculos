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
   [XmlRoot(ElementName = "Lugar" )]
   [XmlType(TypeName =  "Lugar" , Namespace = "ObligatorioFinal" )]
   [Serializable]
   public class SdtLugar : GxSilentTrnSdt
   {
      public SdtLugar( )
      {
      }

      public SdtLugar( IGxContext context )
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

      public void Load( short AV3LugarId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV3LugarId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"LugarId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Lugar");
         metadata.Set("BT", "Lugar");
         metadata.Set("PK", "[ \"LugarId\" ]");
         metadata.Set("PKAssigned", "[ \"LugarId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"PaisId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Lugarfoto_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Lugarid_Z");
         state.Add("gxTpr_Lugarnombre_Z");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Paisnombre_Z");
         state.Add("gxTpr_Lugardireccion_Z");
         state.Add("gxTpr_Lugarfoto_gxi_Z");
         state.Add("gxTpr_Lugarfoto_N");
         state.Add("gxTpr_Lugarfoto_gxi_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtLugar sdt;
         sdt = (SdtLugar)(source);
         gxTv_SdtLugar_Lugarid = sdt.gxTv_SdtLugar_Lugarid ;
         gxTv_SdtLugar_Lugarnombre = sdt.gxTv_SdtLugar_Lugarnombre ;
         gxTv_SdtLugar_Lugarfoto = sdt.gxTv_SdtLugar_Lugarfoto ;
         gxTv_SdtLugar_Lugarfoto_gxi = sdt.gxTv_SdtLugar_Lugarfoto_gxi ;
         gxTv_SdtLugar_Paisid = sdt.gxTv_SdtLugar_Paisid ;
         gxTv_SdtLugar_Paisnombre = sdt.gxTv_SdtLugar_Paisnombre ;
         gxTv_SdtLugar_Lugardireccion = sdt.gxTv_SdtLugar_Lugardireccion ;
         gxTv_SdtLugar_Mode = sdt.gxTv_SdtLugar_Mode ;
         gxTv_SdtLugar_Initialized = sdt.gxTv_SdtLugar_Initialized ;
         gxTv_SdtLugar_Lugarid_Z = sdt.gxTv_SdtLugar_Lugarid_Z ;
         gxTv_SdtLugar_Lugarnombre_Z = sdt.gxTv_SdtLugar_Lugarnombre_Z ;
         gxTv_SdtLugar_Paisid_Z = sdt.gxTv_SdtLugar_Paisid_Z ;
         gxTv_SdtLugar_Paisnombre_Z = sdt.gxTv_SdtLugar_Paisnombre_Z ;
         gxTv_SdtLugar_Lugardireccion_Z = sdt.gxTv_SdtLugar_Lugardireccion_Z ;
         gxTv_SdtLugar_Lugarfoto_gxi_Z = sdt.gxTv_SdtLugar_Lugarfoto_gxi_Z ;
         gxTv_SdtLugar_Lugarfoto_N = sdt.gxTv_SdtLugar_Lugarfoto_N ;
         gxTv_SdtLugar_Lugarfoto_gxi_N = sdt.gxTv_SdtLugar_Lugarfoto_gxi_N ;
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
         AddObjectProperty("LugarId", gxTv_SdtLugar_Lugarid, false, includeNonInitialized);
         AddObjectProperty("LugarNombre", gxTv_SdtLugar_Lugarnombre, false, includeNonInitialized);
         AddObjectProperty("LugarFoto", gxTv_SdtLugar_Lugarfoto, false, includeNonInitialized);
         AddObjectProperty("LugarFoto_N", gxTv_SdtLugar_Lugarfoto_N, false, includeNonInitialized);
         AddObjectProperty("PaisId", gxTv_SdtLugar_Paisid, false, includeNonInitialized);
         AddObjectProperty("PaisNombre", gxTv_SdtLugar_Paisnombre, false, includeNonInitialized);
         AddObjectProperty("LugarDireccion", gxTv_SdtLugar_Lugardireccion, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("LugarFoto_GXI", gxTv_SdtLugar_Lugarfoto_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtLugar_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtLugar_Initialized, false, includeNonInitialized);
            AddObjectProperty("LugarId_Z", gxTv_SdtLugar_Lugarid_Z, false, includeNonInitialized);
            AddObjectProperty("LugarNombre_Z", gxTv_SdtLugar_Lugarnombre_Z, false, includeNonInitialized);
            AddObjectProperty("PaisId_Z", gxTv_SdtLugar_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisNombre_Z", gxTv_SdtLugar_Paisnombre_Z, false, includeNonInitialized);
            AddObjectProperty("LugarDireccion_Z", gxTv_SdtLugar_Lugardireccion_Z, false, includeNonInitialized);
            AddObjectProperty("LugarFoto_GXI_Z", gxTv_SdtLugar_Lugarfoto_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("LugarFoto_N", gxTv_SdtLugar_Lugarfoto_N, false, includeNonInitialized);
            AddObjectProperty("LugarFoto_GXI_N", gxTv_SdtLugar_Lugarfoto_gxi_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtLugar sdt )
      {
         if ( sdt.IsDirty("LugarId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugarid = sdt.gxTv_SdtLugar_Lugarid ;
         }
         if ( sdt.IsDirty("LugarNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugarnombre = sdt.gxTv_SdtLugar_Lugarnombre ;
         }
         if ( sdt.IsDirty("LugarFoto") )
         {
            gxTv_SdtLugar_Lugarfoto_N = (short)(sdt.gxTv_SdtLugar_Lugarfoto_N);
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugarfoto = sdt.gxTv_SdtLugar_Lugarfoto ;
         }
         if ( sdt.IsDirty("LugarFoto") )
         {
            gxTv_SdtLugar_Lugarfoto_gxi_N = (short)(sdt.gxTv_SdtLugar_Lugarfoto_gxi_N);
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugarfoto_gxi = sdt.gxTv_SdtLugar_Lugarfoto_gxi ;
         }
         if ( sdt.IsDirty("PaisId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLugar_Paisid = sdt.gxTv_SdtLugar_Paisid ;
         }
         if ( sdt.IsDirty("PaisNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtLugar_Paisnombre = sdt.gxTv_SdtLugar_Paisnombre ;
         }
         if ( sdt.IsDirty("LugarDireccion") )
         {
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugardireccion = sdt.gxTv_SdtLugar_Lugardireccion ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "LugarId" )]
      [  XmlElement( ElementName = "LugarId"   )]
      public short gxTpr_Lugarid
      {
         get {
            return gxTv_SdtLugar_Lugarid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtLugar_Lugarid != value )
            {
               gxTv_SdtLugar_Mode = "INS";
               this.gxTv_SdtLugar_Lugarid_Z_SetNull( );
               this.gxTv_SdtLugar_Lugarnombre_Z_SetNull( );
               this.gxTv_SdtLugar_Paisid_Z_SetNull( );
               this.gxTv_SdtLugar_Paisnombre_Z_SetNull( );
               this.gxTv_SdtLugar_Lugardireccion_Z_SetNull( );
               this.gxTv_SdtLugar_Lugarfoto_gxi_Z_SetNull( );
            }
            gxTv_SdtLugar_Lugarid = value;
            SetDirty("Lugarid");
         }

      }

      [  SoapElement( ElementName = "LugarNombre" )]
      [  XmlElement( ElementName = "LugarNombre"   )]
      public string gxTpr_Lugarnombre
      {
         get {
            return gxTv_SdtLugar_Lugarnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugarnombre = value;
            SetDirty("Lugarnombre");
         }

      }

      [  SoapElement( ElementName = "LugarFoto" )]
      [  XmlElement( ElementName = "LugarFoto"   )]
      [GxUpload()]
      public string gxTpr_Lugarfoto
      {
         get {
            return gxTv_SdtLugar_Lugarfoto ;
         }

         set {
            gxTv_SdtLugar_Lugarfoto_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugarfoto = value;
            SetDirty("Lugarfoto");
         }

      }

      public void gxTv_SdtLugar_Lugarfoto_SetNull( )
      {
         gxTv_SdtLugar_Lugarfoto_N = 1;
         gxTv_SdtLugar_Lugarfoto = "";
         SetDirty("Lugarfoto");
         return  ;
      }

      public bool gxTv_SdtLugar_Lugarfoto_IsNull( )
      {
         return (gxTv_SdtLugar_Lugarfoto_N==1) ;
      }

      [  SoapElement( ElementName = "LugarFoto_GXI" )]
      [  XmlElement( ElementName = "LugarFoto_GXI"   )]
      public string gxTpr_Lugarfoto_gxi
      {
         get {
            return gxTv_SdtLugar_Lugarfoto_gxi ;
         }

         set {
            gxTv_SdtLugar_Lugarfoto_gxi_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugarfoto_gxi = value;
            SetDirty("Lugarfoto_gxi");
         }

      }

      public void gxTv_SdtLugar_Lugarfoto_gxi_SetNull( )
      {
         gxTv_SdtLugar_Lugarfoto_gxi_N = 1;
         gxTv_SdtLugar_Lugarfoto_gxi = "";
         SetDirty("Lugarfoto_gxi");
         return  ;
      }

      public bool gxTv_SdtLugar_Lugarfoto_gxi_IsNull( )
      {
         return (gxTv_SdtLugar_Lugarfoto_gxi_N==1) ;
      }

      [  SoapElement( ElementName = "PaisId" )]
      [  XmlElement( ElementName = "PaisId"   )]
      public short gxTpr_Paisid
      {
         get {
            return gxTv_SdtLugar_Paisid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLugar_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "PaisNombre" )]
      [  XmlElement( ElementName = "PaisNombre"   )]
      public string gxTpr_Paisnombre
      {
         get {
            return gxTv_SdtLugar_Paisnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLugar_Paisnombre = value;
            SetDirty("Paisnombre");
         }

      }

      [  SoapElement( ElementName = "LugarDireccion" )]
      [  XmlElement( ElementName = "LugarDireccion"   )]
      public string gxTpr_Lugardireccion
      {
         get {
            return gxTv_SdtLugar_Lugardireccion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugardireccion = value;
            SetDirty("Lugardireccion");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtLugar_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLugar_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtLugar_Mode_SetNull( )
      {
         gxTv_SdtLugar_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtLugar_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtLugar_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLugar_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtLugar_Initialized_SetNull( )
      {
         gxTv_SdtLugar_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtLugar_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarId_Z" )]
      [  XmlElement( ElementName = "LugarId_Z"   )]
      public short gxTpr_Lugarid_Z
      {
         get {
            return gxTv_SdtLugar_Lugarid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugarid_Z = value;
            SetDirty("Lugarid_Z");
         }

      }

      public void gxTv_SdtLugar_Lugarid_Z_SetNull( )
      {
         gxTv_SdtLugar_Lugarid_Z = 0;
         SetDirty("Lugarid_Z");
         return  ;
      }

      public bool gxTv_SdtLugar_Lugarid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarNombre_Z" )]
      [  XmlElement( ElementName = "LugarNombre_Z"   )]
      public string gxTpr_Lugarnombre_Z
      {
         get {
            return gxTv_SdtLugar_Lugarnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugarnombre_Z = value;
            SetDirty("Lugarnombre_Z");
         }

      }

      public void gxTv_SdtLugar_Lugarnombre_Z_SetNull( )
      {
         gxTv_SdtLugar_Lugarnombre_Z = "";
         SetDirty("Lugarnombre_Z");
         return  ;
      }

      public bool gxTv_SdtLugar_Lugarnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisId_Z" )]
      [  XmlElement( ElementName = "PaisId_Z"   )]
      public short gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtLugar_Paisid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLugar_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtLugar_Paisid_Z_SetNull( )
      {
         gxTv_SdtLugar_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtLugar_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisNombre_Z" )]
      [  XmlElement( ElementName = "PaisNombre_Z"   )]
      public string gxTpr_Paisnombre_Z
      {
         get {
            return gxTv_SdtLugar_Paisnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLugar_Paisnombre_Z = value;
            SetDirty("Paisnombre_Z");
         }

      }

      public void gxTv_SdtLugar_Paisnombre_Z_SetNull( )
      {
         gxTv_SdtLugar_Paisnombre_Z = "";
         SetDirty("Paisnombre_Z");
         return  ;
      }

      public bool gxTv_SdtLugar_Paisnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarDireccion_Z" )]
      [  XmlElement( ElementName = "LugarDireccion_Z"   )]
      public string gxTpr_Lugardireccion_Z
      {
         get {
            return gxTv_SdtLugar_Lugardireccion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugardireccion_Z = value;
            SetDirty("Lugardireccion_Z");
         }

      }

      public void gxTv_SdtLugar_Lugardireccion_Z_SetNull( )
      {
         gxTv_SdtLugar_Lugardireccion_Z = "";
         SetDirty("Lugardireccion_Z");
         return  ;
      }

      public bool gxTv_SdtLugar_Lugardireccion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarFoto_GXI_Z" )]
      [  XmlElement( ElementName = "LugarFoto_GXI_Z"   )]
      public string gxTpr_Lugarfoto_gxi_Z
      {
         get {
            return gxTv_SdtLugar_Lugarfoto_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugarfoto_gxi_Z = value;
            SetDirty("Lugarfoto_gxi_Z");
         }

      }

      public void gxTv_SdtLugar_Lugarfoto_gxi_Z_SetNull( )
      {
         gxTv_SdtLugar_Lugarfoto_gxi_Z = "";
         SetDirty("Lugarfoto_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtLugar_Lugarfoto_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarFoto_N" )]
      [  XmlElement( ElementName = "LugarFoto_N"   )]
      public short gxTpr_Lugarfoto_N
      {
         get {
            return gxTv_SdtLugar_Lugarfoto_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugarfoto_N = value;
            SetDirty("Lugarfoto_N");
         }

      }

      public void gxTv_SdtLugar_Lugarfoto_N_SetNull( )
      {
         gxTv_SdtLugar_Lugarfoto_N = 0;
         SetDirty("Lugarfoto_N");
         return  ;
      }

      public bool gxTv_SdtLugar_Lugarfoto_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarFoto_GXI_N" )]
      [  XmlElement( ElementName = "LugarFoto_GXI_N"   )]
      public short gxTpr_Lugarfoto_gxi_N
      {
         get {
            return gxTv_SdtLugar_Lugarfoto_gxi_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLugar_Lugarfoto_gxi_N = value;
            SetDirty("Lugarfoto_gxi_N");
         }

      }

      public void gxTv_SdtLugar_Lugarfoto_gxi_N_SetNull( )
      {
         gxTv_SdtLugar_Lugarfoto_gxi_N = 0;
         SetDirty("Lugarfoto_gxi_N");
         return  ;
      }

      public bool gxTv_SdtLugar_Lugarfoto_gxi_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtLugar_Lugarnombre = "";
         gxTv_SdtLugar_Lugarfoto = "";
         gxTv_SdtLugar_Lugarfoto_gxi = "";
         gxTv_SdtLugar_Paisnombre = "";
         gxTv_SdtLugar_Lugardireccion = "";
         gxTv_SdtLugar_Mode = "";
         gxTv_SdtLugar_Lugarnombre_Z = "";
         gxTv_SdtLugar_Paisnombre_Z = "";
         gxTv_SdtLugar_Lugardireccion_Z = "";
         gxTv_SdtLugar_Lugarfoto_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "lugar", "GeneXus.Programs.lugar_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtLugar_Lugarid ;
      private short sdtIsNull ;
      private short gxTv_SdtLugar_Paisid ;
      private short gxTv_SdtLugar_Initialized ;
      private short gxTv_SdtLugar_Lugarid_Z ;
      private short gxTv_SdtLugar_Paisid_Z ;
      private short gxTv_SdtLugar_Lugarfoto_N ;
      private short gxTv_SdtLugar_Lugarfoto_gxi_N ;
      private string gxTv_SdtLugar_Lugarnombre ;
      private string gxTv_SdtLugar_Paisnombre ;
      private string gxTv_SdtLugar_Lugardireccion ;
      private string gxTv_SdtLugar_Mode ;
      private string gxTv_SdtLugar_Lugarnombre_Z ;
      private string gxTv_SdtLugar_Paisnombre_Z ;
      private string gxTv_SdtLugar_Lugardireccion_Z ;
      private string gxTv_SdtLugar_Lugarfoto_gxi ;
      private string gxTv_SdtLugar_Lugarfoto_gxi_Z ;
      private string gxTv_SdtLugar_Lugarfoto ;
   }

   [DataContract(Name = @"Lugar", Namespace = "ObligatorioFinal")]
   public class SdtLugar_RESTInterface : GxGenericCollectionItem<SdtLugar>
   {
      public SdtLugar_RESTInterface( ) : base()
      {
      }

      public SdtLugar_RESTInterface( SdtLugar psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LugarId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Lugarid
      {
         get {
            return sdt.gxTpr_Lugarid ;
         }

         set {
            sdt.gxTpr_Lugarid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "LugarNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Lugarnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Lugarnombre) ;
         }

         set {
            sdt.gxTpr_Lugarnombre = value;
         }

      }

      [DataMember( Name = "LugarFoto" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Lugarfoto
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Lugarfoto)) ? PathUtil.RelativeURL( sdt.gxTpr_Lugarfoto) : StringUtil.RTrim( sdt.gxTpr_Lugarfoto_gxi)) ;
         }

         set {
            sdt.gxTpr_Lugarfoto = value;
         }

      }

      [DataMember( Name = "PaisId" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Paisid
      {
         get {
            return sdt.gxTpr_Paisid ;
         }

         set {
            sdt.gxTpr_Paisid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PaisNombre" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Paisnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Paisnombre) ;
         }

         set {
            sdt.gxTpr_Paisnombre = value;
         }

      }

      [DataMember( Name = "LugarDireccion" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Lugardireccion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Lugardireccion) ;
         }

         set {
            sdt.gxTpr_Lugardireccion = value;
         }

      }

      public SdtLugar sdt
      {
         get {
            return (SdtLugar)Sdt ;
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
            sdt = new SdtLugar() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 6 )]
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

   [DataContract(Name = @"Lugar", Namespace = "ObligatorioFinal")]
   public class SdtLugar_RESTLInterface : GxGenericCollectionItem<SdtLugar>
   {
      public SdtLugar_RESTLInterface( ) : base()
      {
      }

      public SdtLugar_RESTLInterface( SdtLugar psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LugarNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Lugarnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Lugarnombre) ;
         }

         set {
            sdt.gxTpr_Lugarnombre = value;
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

      public SdtLugar sdt
      {
         get {
            return (SdtLugar)Sdt ;
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
            sdt = new SdtLugar() ;
         }
      }

   }

}
