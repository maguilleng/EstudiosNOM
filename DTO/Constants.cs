using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Constants
    {
        #region Placeholders Categorías Reporte NOM35
        public const string Nom35CategoriaAmbienteTrabajo = "AMB_TRABAJO";
        public const string Nom35CategoriaFactoresPropiosActividad = "FAC_ACTIVIDAD";
        public const string Nom35CategoriaOrgTiempoTrabajo = "TIEMPO_TRABAJO";
        public const string Nom35CategoriaLiderazgoRelaciones = "LIDERAZGO_RELACIONES";
        public const string Nom35CategoriaCalificacionFinal = "CAL_FINAL";
        #endregion

        #region Placeholders generales reporte NOM35
        public const string TituloReporte = "@TITULO_REPORTE";
        public const string InstalacionEstudio = "@INSTALACION_ESTUDIO";
        public const string FechaReporteMesAnio = "@FECHA_REPORTE_MES_ANIO";
        public const string FechaLargaReporte = "@FECHA_REPORTE_LONG";
        public const string RazonSocial = "@RAZON_SOCIAL_EMPRESA";
        public const string CantidadTrabajadores = "@NUM_TRABAJADORES";
        public const string PorcentajeFemenino = "@PORCENTAJE_FEMENINO";
        public const string PorcentajeMasculino = "@PORCENTAJE_MASCULINO";
        #endregion

        #region Placeholders Rangos de edad reporte NOM35
        public const string RangoEdadPorc15_19 = "@PORCENTAJE_EDAD_15_19";
        public const string RangoEdadCant15_19 = "@CANTIDAD_EDAD_15_19";
        public const string RangoEdadPorc20_24 = "@PORCENTAJE_EDAD_20_24";
        public const string RangoEdadCant20_24 = "@CANTIDAD_EDAD_20_24";
        public const string RangoEdadPorc25_29 = "@PORCENTAJE_EDAD_25_29";
        public const string RangoEdadCant25_29 = "@CANTIDAD_EDAD_25_29";
        public const string RangoEdadPorc30_34 = "@PORCENTAJE_EDAD_30_34";
        public const string RangoEdadCant30_34 = "@CANTIDAD_EDAD_30_34";
        public const string RangoEdadPorc35_39 = "@PORCENTAJE_EDAD_35_39";
        public const string RangoEdadCant35_39 = "@CANTIDAD_EDAD_35_39";
        public const string RangoEdadPorc40_44 = "@PORCENTAJE_EDAD_40_44";
        public const string RangoEdadCant40_44 = "@CANTIDAD_EDAD_40_44";
        public const string RangoEdadPorc45_49 = "@PORCENTAJE_EDAD_45_49";
        public const string RangoEdadCant45_49 = "@CANTIDAD_EDAD_45_49";
        public const string RangoEdadPorc50_54 = "@PORCENTAJE_EDAD_50_54";
        public const string RangoEdadCant50_54 = "@CANTIDAD_EDAD_50_54";
        public const string RangoEdadPorc55_59 = "@PORCENTAJE_EDAD_55_59";
        public const string RangoEdadCant55_59 = "@CANTIDAD_EDAD_55_59";
        public const string RangoEdadPorc60_64 = "@PORCENTAJE_EDAD_60_64";
        public const string RangoEdadCant60_64 = "@CANTIDAD_EDAD_60_64";
        public const string RangoEdadPorc65_69 = "@PORCENTAJE_EDAD_65_69";
        public const string RangoEdadCant65_69 = "@CANTIDAD_EDAD_65_69";
        public const string RangoEdadPorc70_Mas = "@PORCENTAJE_EDAD_70_MAS";
        public const string RangoEdadCant70_Mas = "@CANTIDAD_EDAD_70_MAS";
        #endregion

        #region Placeholders Antiguedad puesto reporte NOM35
        public const string AntiguedadPuestoPorc_Menos6M = "@PORCENTAJE_ANTIGUEDAD_Menos6M";
        public const string AntiguedadPuestoCant_Menos6M = "@CANTIDAD_ANTIGUEDAD_Menos6M";
        public const string AntiguedadPuestoPorc_6M_1A = "@PORCENTAJE_ANTIGUEDAD_6M_1A";
        public const string AntiguedadPuestoCant_6M_1A = "@CANTIDAD_ANTIGUEDAD_6M_1A";
        public const string AntiguedadPuestoPorc_1A_4A = "@PORCENTAJE_ANTIGUEDAD_1A_4A";
        public const string AntiguedadPuestoCant_1A_4A = "@CANTIDAD_ANTIGUEDAD_1A_4A";
        public const string AntiguedadPuestoPorc_5A_9A = "@PORCENTAJE_ANTIGUEDAD_5A_9A";
        public const string AntiguedadPuestoCant_5A_9A = "@CANTIDAD_ANTIGUEDAD_5A_9A";
        public const string AntiguedadPuestoPorc_10A_14A = "@PORCENTAJE_ANTIGUEDAD_10A_14A";
        public const string AntiguedadPuestoCant_10A_14A = "@CANTIDAD_ANTIGUEDAD_10A_14A";
        public const string AntiguedadPuestoPorc_15A_19A = "@PORCENTAJE_ANTIGUEDAD_15A_19A";
        public const string AntiguedadPuestoCant_15A_19A = "@CANTIDAD_ANTIGUEDAD_15A_19A";
        public const string AntiguedadPuestoPorc_20A_24A = "@PORCENTAJE_ANTIGUEDAD_20A_24A";
        public const string AntiguedadPuestoCant_20A_24A = "@CANTIDAD_ANTIGUEDAD_20A_24A";
        public const string AntiguedadPuestoPorc_25_Mas = "@PORCENTAJE_ANTIGUEDAD_25A";
        public const string AntiguedadPuestoCant_25_Mas = "@CANTIDAD_ANTIGUEDAD_25A";
        #endregion

        #region Placeholders Jornada Laboral reporte NOM35
        public const string JornadaLaboralPorcDiurno = "@PORCENTAJE_JORNADA_DIURNO";
        public const string JornadaLaboralCantDiurno = "@CANTIDAD_JORNADA_DIURNO";
        public const string JornadaLaboralPorcNocturno = "@PORCENTAJE_JORNADA_NOCTURNO";
        public const string JornadaLaboralCantNocturno = "@CANTIDAD_JORNADA_NOCTURNO";
        public const string JornadaLaboralPorcMixto = "@PORCENTAJE_JORNADA_MIXTO";
        public const string JornadaLaboralCantMixto = "@CANTIDAD_JORNADA_MIXTO";
        #endregion

        #region Placeholders Escolaridad reporte NOM35
        public const string EscolaridadPorcSinFormacion = "@PORCENTAJE_ESCOLARIDAD_SIN_FORMACION";
        public const string EscolaridadCantSinFormacion = "@CANTIDAD_ESCOLARIDAD_SIN_FORMACION";
        public const string EscolaridadPorcPrimaria = "@PORCENTAJE_ESCOLARIDAD_PRIMARIA";
        public const string EscolaridadCantPrimaria = "@CANTIDAD_ESCOLARIDAD_PRIMARIA";
        public const string EscolaridadPorcSecundaria = "@PORCENTAJE_ESCOLARIDAD_SECUNDARIA";
        public const string EscolaridadCantSecundaria = "@CANTIDAD_ESCOLARIDAD_SECUNDARIA";
        public const string EscolaridadPorcPreparatoria = "@PORCENTAJE_ESCOLARIDAD_PREPARATORIA";
        public const string EscolaridadCantPreparatoria = "@CANTIDAD_ESCOLARIDAD_PREPARATORIA";
        public const string EscolaridadPorcTecnico = "@PORCENTAJE_ESCOLARIDAD_TECNICO";
        public const string EscolaridadCantTecnico = "@CANTIDAD_ESCOLARIDAD_TECNICO";
        public const string EscolaridadPorcLicenciatura = "@PORCENTAJE_ESCOLARIDAD_LICENCIATURA";
        public const string EscolaridadCantLicenciatura = "@CANTIDAD_ESCOLARIDAD_LICENCIATURA";
        public const string EscolaridadPorcMaestria = "@PORCENTAJE_ESCOLARIDAD_MAESTRIA";
        public const string EscolaridadCantMaestria = "@CANTIDAD_ESCOLARIDAD_MAESTRIA";
        public const string EscolaridadPorcDoctorado = "@PORCENTAJE_ESCOLARIDAD_DOCTORADO";
        public const string EscolaridadCantDoctorado = "@CANTIDAD_ESCOLARIDAD_DOCTORADO";
        #endregion

        #region Placeholders Conclusiones reporte NOM35
        public const string ConclPorcAconTraumaticosSeveros = "@CONCLUSION_PORC_ACONT_TRAUM_SEV";
        public const string ConclCantAconTraumaticosSeveros = "@CONCLUSION_CANT_ACONT_TRAUM_SEV";

        public const string ConclPorcCatAmbTrab = "@CONCLUSION_PORC_CAT_AMB_TRAB";
        public const string ConclCantCatAmbTrab = "@CONCLUSION_CANT_CAT_AMB_TRAB";
        public const string ConclDescCatAmbTrab = "@CONCLUSION_DESC_CAT_AMB_TRAB";

        public const string ConclPorcCatFacPropAct = "@CONCLUSION_PORC_CAT_FAC_PROP_ACT";
        public const string ConclCantCatFacPropAct = "@CONCLUSION_CANT_CAT_FAC_PROP_ACT";
        public const string ConclDescCatFacPropAct = "@CONCLUSION_DESC_CAT_FAC_PROP_ACT";

        public const string ConclPorcDomFaltaCtrlTrab = "@CONCLUSION_PORC_DOM_FALTA_CTRL_TRAB";
        public const string ConclCantDomFaltaCtrlTrab = "@CONCLUSION_CANT_DOM_FALTA_CTRL_TRAB";
        public const string ConclDescDomFaltaCtrlTrab = "@CONCLUSION_DESC_DOM_FALTA_CTRL_TRAB";

        public const string ConclPorcDomCargaTrab = "@CONCLUSION_PORC_DOM_CARGA_TRAB";
        public const string ConclCantDomCargaTrab = "@CONCLUSION_CANT_DOM_CARGA_TRAB";
        public const string ConclDescDomCargaTrab = "@CONCLUSION_DESC_DOM_CARGA_TRAB";

        public const string ConclPorcCatOrgTiempoTrab = "@CONCLUSION_PORC_CAT_ORG_TIEMPO_TRAB";
        public const string ConclCantCatOrgTiempoTrab = "@CONCLUSION_CANT_CAT_ORG_TIEMPO_TRAB";
        public const string ConclDescCatOrgTiempoTrab = "@CONCLUSION_DESC_CAT_ORG_TIEMPO_TRAB";

        public const string ConclPorcDomJorTrab = "@CONCLUSION_PORC_DOM_JOR_TRAB";
        public const string ConclCantDomJorTrab = "@CONCLUSION_CANT_DOM_JOR_TRAB";
        public const string ConclDescDomJorTrab = "@CONCLUSION_DESC_DOM_JOR_TRAB";

        public const string ConclPorcDomInterTrabFam = "@CONCLUSION_PORC_DOM_INTER_TRAB_FAM";
        public const string ConclCantDomInterTrabFam = "@CONCLUSION_CANT_DOM_INTER_TRAB_FAM";
        public const string ConclDescDomInterTrabFam = "@CONCLUSION_DESC_DOM_INTER_TRAB_FAM";

        public const string ConclPorcCatLiderazgoRelTrab = "@CONCLUSION_PORC_DOM_LIDERAZGO_REL_TRAB";
        public const string ConclCantCatLiderazgoRelTrab = "@CONCLUSION_CANT_DOM_LIDERAZGO_REL_TRAB";
        public const string ConclDescCatLiderazgoRelTrab = "@CONCLUSION_DESC_DOM_LIDERAZGO_REL_TRAB";

        public const string ConclPorcDomLiderazgo = "@CONCLUSION_PORC_DOM_LIDERAZGOCAT";
        public const string ConclCantDomLiderazgo = "@CONCLUSION_CANT_DOM_LIDERAZGOCAT";
        public const string ConclDescDomLiderazgo = "@CONCLUSION_DESC_DOM_LIDERAZGOCAT";

        public const string ConclPorcDomRelTrab = "@CONCLUSION_PORC_DOM_REL_TRAB";
        public const string ConclCantDomRelTrab = "@CONCLUSION_CANT_DOM_REL_TRAB";
        public const string ConclDescDomRelTrab = "@CONCLUSION_DESC_DOM_REL_TRAB";

        public const string ConclPorcDomViolencia = "@CONCLUSION_PORC_DOM_VIOLENCIA";
        public const string ConclCantDomViolencia = "@CONCLUSION_CANT_DOM_VIOLENCIA";
        public const string ConclDescDomViolencia = "@CONCLUSION_DESC_DOM_VIOLENCIA";

        public const string ConclPorcDomSinViolencia = "@CONCLUSION_PORC_DOM_SIN_VIOLENCIA";
        public const string ConclCantDomSinViolencia = "@CONCLUSION_CANT_DOM_SIN_VIOLENCIA";
        public const string ConclDescDomSinViolencia = "@CONCLUSION_DESC_DOM_SIN_VIOLENCIA";
        #endregion
    }
}
