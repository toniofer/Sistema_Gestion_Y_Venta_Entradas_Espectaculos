using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.general.ui {
   public class sidebaritemsdp : GXProcedure
   {
      public sidebaritemsdp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public sidebaritemsdp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem>( context, "SidebarItem", "GeneXusUnanimo") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP0_Gxm2rootcol )
      {
         sidebaritemsdp objsidebaritemsdp;
         objsidebaritemsdp = new sidebaritemsdp();
         objsidebaritemsdp.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem>( context, "SidebarItem", "GeneXusUnanimo") ;
         objsidebaritemsdp.context.SetSubmitInitialConfig(context);
         objsidebaritemsdp.initialize();
         Submit( executePrivateCatch,objsidebaritemsdp);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sidebaritemsdp)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_objcol_SdtProgramNames_ProgramName1 = AV5wwProgramNames;
         new GeneXus.Programs.general.ui.listprograms(context ).execute( out  GXt_objcol_SdtProgramNames_ProgramName1) ;
         AV5wwProgramNames = GXt_objcol_SdtProgramNames_ProgramName1;
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV5wwProgramNames.Count )
         {
            AV6wwProgramName = ((GeneXus.Programs.general.ui.SdtProgramNames_ProgramName)AV5wwProgramNames.Item(AV12GXV1));
            Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
            Gxm2rootcol.Add(Gxm1sidebaritems, 0);
            Gxm1sidebaritems.gxTpr_Id = AV6wwProgramName.gxTpr_Name;
            Gxm1sidebaritems.gxTpr_Title = AV6wwProgramName.gxTpr_Description;
            Gxm1sidebaritems.gxTpr_Target = AV6wwProgramName.gxTpr_Link;
            Gxm1sidebaritems.gxTpr_Hassubitems = false;
            AV12GXV1 = (int)(AV12GXV1+1);
         }
         Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
         Gxm2rootcol.Add(Gxm1sidebaritems, 0);
         Gxm1sidebaritems.gxTpr_Id = "Listados";
         Gxm1sidebaritems.gxTpr_Title = "LISTADOS Y MÁS";
         Gxm1sidebaritems.gxTpr_Hassubitems = true;
         Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
         Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "ListadoEspectaculosGeneral";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Listado de Espectaculos General";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("alistadoespectaculosgeneral.aspx") ;
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
         Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
         Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "ListadoEspectaculosPorTipo";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Listado de Espectaculos por Tipo";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("alistadoespectaculosportipo.aspx") ;
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
         Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
         Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "ListadoConciertosPorFecha";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Listado de Conciertos por Fecha";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("conciertosporfecha.aspx") ;
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
         Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
         Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "Espectaculos agrupados por tipo";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Espectáculos agrupados por tipo";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("espectaculosportipoespectaculo.aspx") ;
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
         Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
         Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "Aumentar precios de entradas";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Aumentar precios de entradas";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("aumentarprecioentradas.aspx") ;
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
         Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
         Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "Pases por espectaculo";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Pases por espectáculo";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("pasesporespectaculoporpais.aspx") ;
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV5wwProgramNames = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "ObligatorioFinal");
         GXt_objcol_SdtProgramNames_ProgramName1 = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "ObligatorioFinal");
         AV6wwProgramName = new GeneXus.Programs.general.ui.SdtProgramNames_ProgramName(context);
         Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
         Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV12GXV1 ;
      private GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> AV5wwProgramNames ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> GXt_objcol_SdtProgramNames_ProgramName1 ;
      private GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> Gxm2rootcol ;
      private GeneXus.Programs.general.ui.SdtProgramNames_ProgramName AV6wwProgramName ;
      private GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem Gxm1sidebaritems ;
      private GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem Gxm3sidebaritems_sidebarsubitems ;
   }

}
