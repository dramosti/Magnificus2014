using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Facade.Magnificus
{
    public static class ImpostosFacade
    {
        public static decimal CalculaBaseIpi(byte IPI_stCompoeBaseCalculo, decimal? vTotalItem,
            decimal? vFreteItem, decimal? vSegurosItem, decimal? vOutrasDespesasItem)
        {
            switch (IPI_stCompoeBaseCalculo)
            {
                case 0:
                    {
                        return vTotalItem ?? 0;
                    }
                case 1:
                    {
                        return (vTotalItem ?? 0) + (vFreteItem ?? 0);
                    }
                case 2:
                    {
                        return (vTotalItem ?? 0) + (vFreteItem ?? 0) + (vSegurosItem ?? 0) + (vOutrasDespesasItem ?? 0);
                    }
                case 3:
                default:
                    {
                        return decimal.Zero;
                    }
            }
        }

        public static decimal CalculaBaseIcms(byte ICMS_stCalculaSubstituicaoTributaria, byte ICMS_stCompoeBaseCalculo, decimal? _vTotalItem, decimal? IPI_vIPI,
            decimal? _vFreteItem, decimal? _vSegurosItem, decimal? _vOutrasDespesasItem, byte ICMS_stReduzBaseCalculo, decimal? ICMS_pReduzBase)
        {
            decimal ICMS_vBaseCalculo = decimal.Zero;
            if (ICMS_stCalculaSubstituicaoTributaria == 0)
            {
                ICMS_vBaseCalculo = _vTotalItem ?? 0;

                if (ICMS_stCompoeBaseCalculo != 5)
                {
                    switch (ICMS_stReduzBaseCalculo)
                    {
                        case 1:
                        case 2:
                            {
                                ICMS_vBaseCalculo -= ICMS_vBaseCalculo *
                                    ((ICMS_pReduzBase ?? 0) / 100);
                            } break;
                    }
                }

                switch (ICMS_stCompoeBaseCalculo)
                {
                    case 1:
                        {
                            ICMS_vBaseCalculo +=
                                (IPI_vIPI ?? 0);
                        } break;
                    case 2:
                        {
                            ICMS_vBaseCalculo +=
                                (IPI_vIPI ?? 0) + (_vFreteItem ?? 0);
                        } break;
                    case 3:
                        {
                            ICMS_vBaseCalculo +=
                                (IPI_vIPI ?? 0) + (_vFreteItem ?? 0)
                                + (_vSegurosItem ?? 0) + (_vOutrasDespesasItem ?? 0);
                        } break;
                    case 4:
                        {
                            ICMS_vBaseCalculo = decimal.Zero;
                        } break;
                }
            }
            return ICMS_vBaseCalculo;
        }

        public static decimal CalculaBaseIcmsProprio(byte ICMS_stCalculaSubstituicaoTributaria, byte ICMS_stCompoeBaseCalculo,
            decimal? vTotalItem, decimal? PIS_vPIS, decimal? vFreteItem, decimal? vSegurosItem,
            decimal? vOutrasDespesasItem, byte ICMS_stReduzBaseCalculo, decimal? ICMS_pReduzBase)
        {
            decimal ICMS_vBaseCalculoIcmsProprio = decimal.Zero;

            if (ICMS_stCalculaSubstituicaoTributaria == 1)
            {
                ICMS_vBaseCalculoIcmsProprio
                                = (vTotalItem ?? 0);

                if (ICMS_stCompoeBaseCalculo != 5)
                {
                    switch (ICMS_stReduzBaseCalculo)
                    {
                        case 1:
                        case 2:
                            {
                                ICMS_vBaseCalculoIcmsProprio -=
                                    ICMS_vBaseCalculoIcmsProprio *
                                    ((ICMS_pReduzBase ?? 0) / 100);
                            }
                            break;
                    }
                }

                switch (ICMS_stCompoeBaseCalculo)
                {
                    case 1:
                        {
                            ICMS_vBaseCalculoIcmsProprio
                                += (PIS_vPIS ?? 0);
                        } break;
                    case 2:
                        {
                            ICMS_vBaseCalculoIcmsProprio
                                += (PIS_vPIS ?? 0) + (vFreteItem ?? 0);
                        } break;
                    case 3:
                        {
                            ICMS_vBaseCalculoIcmsProprio
                                += (PIS_vPIS ?? 0) + (vFreteItem ?? 0)
                                + (vSegurosItem ?? 0) + (vOutrasDespesasItem ?? 0);
                        } break;
                    case 4:
                        {
                            ICMS_vBaseCalculoIcmsProprio = 0;
                        } break;
                }
            }
            return ICMS_vBaseCalculoIcmsProprio;
        }

        public static decimal CalculaBaseIcmsSubstTrib(byte stSubsticaoTributariaIcmsDiferenciada, byte ICMS_stCompoeBaseCalculoSubstituicaoTributaria,
            byte _stConsumidorFinal, byte stContribuinteIcms, decimal? _vTotalItem, decimal? ICMS_pMvaSubstituicaoTributaria,
            decimal? IPI_vIPI, decimal? _vFreteItem, decimal? _vSegurosItem, decimal? _vOutrasDespesasItem, decimal? ICMS_pIcmsInterno, decimal? ICMS_vIcmsProprio,
            decimal? ICMS_vSubstituicaoTributaria, byte ICMS_stReduzBaseCalculo, decimal? pReduzBaseSubstituicaoTributaria)
        {
            decimal ICMS_vBaseCalculoSubstituicaoTributaria = decimal.Zero;
            if (stSubsticaoTributariaIcmsDiferenciada == 0)
                ICMS_stCompoeBaseCalculoSubstituicaoTributaria = 4;

            if (ICMS_stCompoeBaseCalculoSubstituicaoTributaria == 0
                || _stConsumidorFinal == 1
                || stContribuinteIcms == 0)
                ICMS_stCompoeBaseCalculoSubstituicaoTributaria = 5;

            ICMS_vBaseCalculoSubstituicaoTributaria = _vTotalItem ?? 0;

            switch (ICMS_stReduzBaseCalculo)
            {
                //(((“Orcamento_Item.vTotalItem” –  (“Orcamento_Item.vTotalItem” X  “pReduzBaseSubstituicaoTributaria” / 100)
                //    + “Orçamento_Item_Impostos.IPI_vIPI” + “Orcamento_Item.vFreteItem” + campo “Orcamento_Item.vSegurosItem” 
                //        + “Orcamento_Item.vOutrasDespesasItem”) X “Orçamento_Item_Impostos.ICMS_pMvaSubstituicaoTributaria” / 100) + “Orcamento_Item.vTotalItem”);
                case 1:
                case 3:
                    {
                        ICMS_vBaseCalculoSubstituicaoTributaria -=
                            (ICMS_vBaseCalculoSubstituicaoTributaria * (pReduzBaseSubstituicaoTributaria ?? 0));
                    } break;
            }
            switch (ICMS_stCompoeBaseCalculoSubstituicaoTributaria)
            {
                case 1:
                    {
                        ICMS_vBaseCalculoSubstituicaoTributaria +=
                            (IPI_vIPI ?? 0);
                    } break;
                case 2:
                    {
                        ICMS_vBaseCalculoSubstituicaoTributaria +=
                            (IPI_vIPI ?? 0) + (_vFreteItem ?? 0);
                    } break;
                case 3:
                    {
                        ICMS_vBaseCalculoSubstituicaoTributaria +=
                            (IPI_vIPI ?? 0) + (_vFreteItem ?? 0)
                            + (_vSegurosItem ?? 0) + (_vOutrasDespesasItem ?? 0);
                    } break;
                case 4:
                    {
                        if ((ICMS_pIcmsInterno ?? 0) != 0)
                            ICMS_vBaseCalculoSubstituicaoTributaria =
                                ((ICMS_vIcmsProprio ?? 0) +
                                (ICMS_vSubstituicaoTributaria ?? 0)) /
                                (ICMS_pIcmsInterno ?? 0);
                    } break;
                case 5:
                    {
                        ICMS_vBaseCalculoSubstituicaoTributaria =
                            0;
                    } break;
            }

            return ICMS_vBaseCalculoSubstituicaoTributaria + (ICMS_vBaseCalculoSubstituicaoTributaria * ((ICMS_pMvaSubstituicaoTributaria ?? 0) / 100));
        }

        public static decimal CalcularVlrSubstTrib(byte stSubsticaoTributariaIcmsDiferenciada, byte ICMS_stCalculaSubstituicaoTributaria, byte stConsumidorFinal,
            byte stContribuinteIcms, string xRamo, int idEstadoCliente, int idEstadoEmpresa, decimal? ICMS_vBaseCalculoSubstituicaoTributaria,
            decimal? ICMS_pICMS, decimal? ICMS_pIcmsInterno, string xSiglaUf, byte ICMS_stCalculaIcms, byte parametros_FiscalEmpresa, decimal ICMS_vICMS)
        {
            decimal ICMS_vSubstituicaoTributaria = decimal.Zero;
            if (ICMS_stCalculaSubstituicaoTributaria == 1
                && stConsumidorFinal == 0
                && stContribuinteIcms == 1
                && stSubsticaoTributariaIcmsDiferenciada == 0)
            {
                ICMS_vBaseCalculoSubstituicaoTributaria = (ICMS_vBaseCalculoSubstituicaoTributaria * (ICMS_pIcmsInterno / 100)
                    ) - ICMS_vICMS;

            }
            else if (ICMS_stCalculaSubstituicaoTributaria == 1
                && stConsumidorFinal == 1
                && stContribuinteIcms == 1
                && stSubsticaoTributariaIcmsDiferenciada == 0
                && xRamo.Trim().Contains(value: "1-COMERCIO")
                && idEstadoCliente != idEstadoEmpresa
                )
            {
                ICMS_vSubstituicaoTributaria =
                    (((ICMS_vBaseCalculoSubstituicaoTributaria ?? 0) *
                    ((ICMS_pICMS ?? 0) - (ICMS_pIcmsInterno ?? 0)) / 100));
            }
            else if (
                ICMS_stCalculaSubstituicaoTributaria == 1
                && stConsumidorFinal == 0
                && stContribuinteIcms == 1
                && stSubsticaoTributariaIcmsDiferenciada != 1
                && xSiglaUf == "MT"
                )
            {
                //(((“Orcamento_Item.vTotalItem” –  (“Orçamento_Item_Impostos.ICMS_pReduzBaseSubstituicaoTributaria” / 100) + 
                //    “Orçamento_Item_Impostos.IPI_vIPI” + “Orcamento_Item.vFreteItem” + “Orcamento_Item.vSegurosItem” + 
                //        “Orcamento_Item.vOutrasDespesasItem”) x (“Orçamento_Item_Impostos.ICMS_stCalculaSubstituicaoTributaria”))
                //TODO: Conferir cálculo
            }
            else if (
                ICMS_stCalculaIcms == 1
                    && stConsumidorFinal == 1
                    && stContribuinteIcms == 0
                    && stSubsticaoTributariaIcmsDiferenciada != 0
                    && xRamo.Trim().Contains(value: "1-COM")
                && idEstadoCliente == idEstadoEmpresa
                && parametros_FiscalEmpresa == (byte)1
                )
            {
                ICMS_vSubstituicaoTributaria = 0;
            }
            else if (
                ICMS_stCalculaIcms == 1
                    && stConsumidorFinal == 1
                    && stContribuinteIcms == 1
                    && stSubsticaoTributariaIcmsDiferenciada != 0
                    && xRamo.Trim().Contains(value: "1-COM")
                && idEstadoCliente != idEstadoEmpresa
                && parametros_FiscalEmpresa == (byte)0
                )
            {
                ICMS_vSubstituicaoTributaria = 0;
            }
            else if (
                ICMS_stCalculaIcms == 1
                    && stConsumidorFinal == 1
                    && stContribuinteIcms == 1
                    && stSubsticaoTributariaIcmsDiferenciada != 0
                    && xRamo.Trim().Contains(value: "1-COM")
                && idEstadoCliente != idEstadoEmpresa
                && parametros_FiscalEmpresa == (byte)1
                )
            {
                ICMS_vSubstituicaoTributaria = 0;
            }

            return ICMS_vSubstituicaoTributaria;
        }

        public static decimal CalcularVlrBasePis(byte stCalculaPisCofins, byte stCompoeBaseCalculoPisCofins, decimal? _vTotalItem, decimal? IPI_vIPI,
            decimal? _vFreteItem, decimal? _vSegurosItem, decimal? _vOutrasDespesasItem, byte PIS_stCompoeBaseCalculoSubstituicaoTributaria)
        {
            byte stCompoeBase = 4;

            switch (stCalculaPisCofins)
            {
                case 0:
                default:
                    {
                        return decimal.Zero;
                    }
                case 1:
                    {
                        stCompoeBase = stCompoeBaseCalculoPisCofins;
                    } break;
                case 2:
                    {
                        stCompoeBase = PIS_stCompoeBaseCalculoSubstituicaoTributaria;
                    } break;
            }

            switch (stCompoeBase)
            {
                case 0:
                    {
                        return (_vTotalItem ?? 0);
                    }
                case 1:
                    {
                        return (_vTotalItem ?? 0) + (IPI_vIPI ?? 0);
                    }
                case 2:
                    {
                        return (_vTotalItem ?? 0) + (IPI_vIPI ?? 0) + (_vFreteItem ?? 0);
                    }
                case 3:
                    {
                        return (_vTotalItem ?? 0) + (IPI_vIPI ?? 0) + (_vFreteItem ?? 0) +
                            (_vSegurosItem ?? 0) + (_vOutrasDespesasItem ?? 0);
                    }
                case 4:
                default:
                    {
                        return decimal.Zero;
                    }
            }
        }

        public static decimal CalcularVlrBaseCofins(byte stCalculaPisCofins, byte stCompoeBaseCalculoPisCofins, byte COFINS_stCompoeBaseCalculoSubstituicaoTributaria,
            decimal? _vTotalItem, decimal? IPI_vIPI, decimal? _vFreteItem, decimal? _vSegurosItem, decimal? _vOutrasDespesasItem)
        {
            byte stCompoeBase = 4;
            switch (stCalculaPisCofins)
            {
                case 0:
                default:
                    {
                        return decimal.Zero;
                    }
                case 1:
                    {
                        stCompoeBase = stCompoeBaseCalculoPisCofins;
                    } break;
                case 2:
                    {
                        stCompoeBase = COFINS_stCompoeBaseCalculoSubstituicaoTributaria;
                    } break;
            }

            switch (stCompoeBase)
            {
                case 0:
                    {
                        return _vTotalItem ?? 0;
                    }
                case 1:
                    {
                        return (_vTotalItem ?? 0) + (IPI_vIPI ?? 0);
                    }
                case 2:
                    {
                        return (_vTotalItem ?? 0) + (IPI_vIPI ?? 0) + (_vFreteItem ?? 0);
                    }
                case 3:
                    {
                        return (_vTotalItem ?? 0) + (IPI_vIPI ?? 0) + (_vFreteItem ?? 0) +
                            (_vSegurosItem ?? 0) + (_vOutrasDespesasItem ?? 0);
                    }
                case 4:
                default:
                    {
                        return decimal.Zero;
                    }
            }
        }
    }
}
