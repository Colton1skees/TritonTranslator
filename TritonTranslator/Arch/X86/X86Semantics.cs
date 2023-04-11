/*
**  Copyright (C) - Triton
**
**  This program is under the terms of the Apache License 2.0.
*/

/*
**  This file is auto-generated.
**
**  Modifications to this class should be inserted from the transpiler.
** 
**  Alternatively, new instruction semantics may be implemented in SemanticPatches.cs
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Ast;
using TritonTranslator.Expression;
using TritonTranslator.Extensions;

namespace TritonTranslator.Arch.X86
{
    /// <summary>
    /// Class for building x86 instruction semantics.
    /// </summary>
    public class X86Semantics
    {
        private readonly ICpuArchitecture architecture;

        private readonly AstContext astCtxt;

        private readonly IAstBuilder astBuilder;

        internal IExpressionDatabase ExpressionDatabase { get; }
        
        public X86Semantics(ICpuArchitecture architecture)
        {
            this.architecture = architecture;
            this.astCtxt = new AstContext();
            this.astBuilder = new AstBuilder(architecture);
            this.ExpressionDatabase = new ExpressionDatabase(astBuilder);
        }

        public void ConditionalUndefine(Instruction inst, Register reg, AbstractNode condition)
        {
            // TODO: Stop doing this.
            return;
            // Conditionally undefine the register.
            var condExpr = astCtxt.ite(condition, astCtxt.undef(reg.BitSize), astBuilder.GetRegisterAst(reg));

            // Update the symbolic engine.
            ExpressionDatabase.StoreSymbolicAssignment(inst, condExpr, reg, "Conditional undefine");
        }

        public bool BuildSemantics(Instruction inst)
        {
            switch (inst.Type)
            {
                case Iced.Intel.Mnemonic.Aaa: this.aaa_s(inst); break;
                case Iced.Intel.Mnemonic.Aad: this.aad_s(inst); break;
                case Iced.Intel.Mnemonic.Aam: this.aam_s(inst); break;
                case Iced.Intel.Mnemonic.Aas: this.aas_s(inst); break;
                case Iced.Intel.Mnemonic.Adc: this.adc_s(inst); break;
                case Iced.Intel.Mnemonic.Adcx: this.adcx_s(inst); break;
                case Iced.Intel.Mnemonic.Add: this.add_s(inst); break;
                case Iced.Intel.Mnemonic.And: this.and_s(inst); break;
                case Iced.Intel.Mnemonic.Andn: this.andn_s(inst); break;
                case Iced.Intel.Mnemonic.Andnpd: this.andnpd_s(inst); break;
                case Iced.Intel.Mnemonic.Andnps: this.andnps_s(inst); break;
                case Iced.Intel.Mnemonic.Andpd: this.andpd_s(inst); break;
                case Iced.Intel.Mnemonic.Andps: this.andps_s(inst); break;
                case Iced.Intel.Mnemonic.Bextr: this.bextr_s(inst); break;
                case Iced.Intel.Mnemonic.Blsi: this.blsi_s(inst); break;
                case Iced.Intel.Mnemonic.Blsmsk: this.blsmsk_s(inst); break;
                case Iced.Intel.Mnemonic.Blsr: this.blsr_s(inst); break;
                case Iced.Intel.Mnemonic.Bsf: this.bsf_s(inst); break;
                case Iced.Intel.Mnemonic.Bsr: this.bsr_s(inst); break;
                case Iced.Intel.Mnemonic.Bswap: this.bswap_s(inst); break;
                case Iced.Intel.Mnemonic.Bt: this.bt_s(inst); break;
                case Iced.Intel.Mnemonic.Btc: this.btc_s(inst); break;
                case Iced.Intel.Mnemonic.Btr: this.btr_s(inst); break;
                case Iced.Intel.Mnemonic.Bts: this.bts_s(inst); break;
                case Iced.Intel.Mnemonic.Call: this.call_s(inst); break;
                case Iced.Intel.Mnemonic.Cbw: this.cbw_s(inst); break;
                case Iced.Intel.Mnemonic.Cdq: this.cdq_s(inst); break;
                case Iced.Intel.Mnemonic.Cdqe: this.cdqe_s(inst); break;
                case Iced.Intel.Mnemonic.Clc: this.clc_s(inst); break;
                case Iced.Intel.Mnemonic.Cld: this.cld_s(inst); break;
                case Iced.Intel.Mnemonic.Clflush: this.clflush_s(inst); break;
                case Iced.Intel.Mnemonic.Clts: this.clts_s(inst); break;
                case Iced.Intel.Mnemonic.Cli: this.cli_s(inst); break;
                case Iced.Intel.Mnemonic.Cmc: this.cmc_s(inst); break;
                case Iced.Intel.Mnemonic.Cmova: this.cmova_s(inst); break;
                case Iced.Intel.Mnemonic.Cmovae: this.cmovae_s(inst); break;
                case Iced.Intel.Mnemonic.Cmovb: this.cmovb_s(inst); break;
                case Iced.Intel.Mnemonic.Cmovbe: this.cmovbe_s(inst); break;
                case Iced.Intel.Mnemonic.Cmove: this.cmove_s(inst); break;
                case Iced.Intel.Mnemonic.Cmovg: this.cmovg_s(inst); break;
                case Iced.Intel.Mnemonic.Cmovge: this.cmovge_s(inst); break;
                case Iced.Intel.Mnemonic.Cmovl: this.cmovl_s(inst); break;
                case Iced.Intel.Mnemonic.Cmovle: this.cmovle_s(inst); break;
                case Iced.Intel.Mnemonic.Cmovne: this.cmovne_s(inst); break;
                case Iced.Intel.Mnemonic.Cmovno: this.cmovno_s(inst); break;
                case Iced.Intel.Mnemonic.Cmovnp: this.cmovnp_s(inst); break;
                case Iced.Intel.Mnemonic.Cmovns: this.cmovns_s(inst); break;
                case Iced.Intel.Mnemonic.Cmovo: this.cmovo_s(inst); break;
                case Iced.Intel.Mnemonic.Cmovp: this.cmovp_s(inst); break;
                case Iced.Intel.Mnemonic.Cmovs: this.cmovs_s(inst); break;
                case Iced.Intel.Mnemonic.Cmp: this.cmp_s(inst); break;
                case Iced.Intel.Mnemonic.Cmpsb: this.cmpsb_s(inst); break;
                case Iced.Intel.Mnemonic.Cmpsd: this.cmpsd_s(inst); break;
                case Iced.Intel.Mnemonic.Cmpsq: this.cmpsq_s(inst); break;
                case Iced.Intel.Mnemonic.Cmpsw: this.cmpsw_s(inst); break;
                case Iced.Intel.Mnemonic.Cmpxchg: this.cmpxchg_s(inst); break;
                case Iced.Intel.Mnemonic.Cmpxchg16b: this.cmpxchg16b_s(inst); break;
                case Iced.Intel.Mnemonic.Cmpxchg8b: this.cmpxchg8b_s(inst); break;
                case Iced.Intel.Mnemonic.Cpuid: this.cpuid_s(inst); break;
                case Iced.Intel.Mnemonic.Cqo: this.cqo_s(inst); break;
                case Iced.Intel.Mnemonic.Cwd: this.cwd_s(inst); break;
                case Iced.Intel.Mnemonic.Cwde: this.cwde_s(inst); break;
                case Iced.Intel.Mnemonic.Dec: this.dec_s(inst); break;
                case Iced.Intel.Mnemonic.Div: this.div_s(inst); break;
                case Iced.Intel.Mnemonic.Endbr32: this.endbr32_s(inst); break;
                case Iced.Intel.Mnemonic.Endbr64: this.endbr64_s(inst); break;
                case Iced.Intel.Mnemonic.Extractps: this.extractps_s(inst); break;
                case Iced.Intel.Mnemonic.Idiv: this.idiv_s(inst); break;
                case Iced.Intel.Mnemonic.Imul: this.imul_s(inst); break;
                case Iced.Intel.Mnemonic.Inc: this.inc_s(inst); break;
                case Iced.Intel.Mnemonic.Invd: this.invd_s(inst); break;
                case Iced.Intel.Mnemonic.Invlpg: this.invlpg_s(inst); break;
                case Iced.Intel.Mnemonic.Ja: this.ja_s(inst); break;
                case Iced.Intel.Mnemonic.Jae: this.jae_s(inst); break;
                case Iced.Intel.Mnemonic.Jb: this.jb_s(inst); break;
                case Iced.Intel.Mnemonic.Jbe: this.jbe_s(inst); break;
                case Iced.Intel.Mnemonic.Jcxz: this.jcxz_s(inst); break;
                case Iced.Intel.Mnemonic.Je: this.je_s(inst); break;
                case Iced.Intel.Mnemonic.Jecxz: this.jecxz_s(inst); break;
                case Iced.Intel.Mnemonic.Jg: this.jg_s(inst); break;
                case Iced.Intel.Mnemonic.Jge: this.jge_s(inst); break;
                case Iced.Intel.Mnemonic.Jl: this.jl_s(inst); break;
                case Iced.Intel.Mnemonic.Jle: this.jle_s(inst); break;
                case Iced.Intel.Mnemonic.Jmp: this.jmp_s(inst); break;
                case Iced.Intel.Mnemonic.Jne: this.jne_s(inst); break;
                case Iced.Intel.Mnemonic.Jno: this.jno_s(inst); break;
                case Iced.Intel.Mnemonic.Jnp: this.jnp_s(inst); break;
                case Iced.Intel.Mnemonic.Jns: this.jns_s(inst); break;
                case Iced.Intel.Mnemonic.Jo: this.jo_s(inst); break;
                case Iced.Intel.Mnemonic.Jp: this.jp_s(inst); break;
                case Iced.Intel.Mnemonic.Jrcxz: this.jrcxz_s(inst); break;
                case Iced.Intel.Mnemonic.Js: this.js_s(inst); break;
                case Iced.Intel.Mnemonic.Lahf: this.lahf_s(inst); break;
                case Iced.Intel.Mnemonic.Lddqu: this.lddqu_s(inst); break;
                case Iced.Intel.Mnemonic.Ldmxcsr: this.ldmxcsr_s(inst); break;
                case Iced.Intel.Mnemonic.Lea: this.lea_s(inst); break;
                case Iced.Intel.Mnemonic.Leave: this.leave_s(inst); break;
                case Iced.Intel.Mnemonic.Lfence: this.lfence_s(inst); break;
                case Iced.Intel.Mnemonic.Lodsb: this.lodsb_s(inst); break;
                case Iced.Intel.Mnemonic.Lodsd: this.lodsd_s(inst); break;
                case Iced.Intel.Mnemonic.Lodsq: this.lodsq_s(inst); break;
                case Iced.Intel.Mnemonic.Lodsw: this.lodsw_s(inst); break;
                case Iced.Intel.Mnemonic.Loop: this.loop_s(inst); break;
                case Iced.Intel.Mnemonic.Lzcnt: this.lzcnt_s(inst); break;
                case Iced.Intel.Mnemonic.Mfence: this.mfence_s(inst); break;
                case Iced.Intel.Mnemonic.Mov: this.mov_s(inst); break;
                case Iced.Intel.Mnemonic.Movapd: this.movapd_s(inst); break;
                case Iced.Intel.Mnemonic.Movaps: this.movaps_s(inst); break;
                case Iced.Intel.Mnemonic.Movbe: this.movbe_s(inst); break;
                case Iced.Intel.Mnemonic.Movd: this.movd_s(inst); break;
                case Iced.Intel.Mnemonic.Movddup: this.movddup_s(inst); break;
                case Iced.Intel.Mnemonic.Movdq2q: this.movdq2q_s(inst); break;
                case Iced.Intel.Mnemonic.Movdqa: this.movdqa_s(inst); break;
                case Iced.Intel.Mnemonic.Movdqu: this.movdqu_s(inst); break;
                case Iced.Intel.Mnemonic.Movhlps: this.movhlps_s(inst); break;
                case Iced.Intel.Mnemonic.Movhpd: this.movhpd_s(inst); break;
                case Iced.Intel.Mnemonic.Movhps: this.movhps_s(inst); break;
                case Iced.Intel.Mnemonic.Movlhps: this.movlhps_s(inst); break;
                case Iced.Intel.Mnemonic.Movlpd: this.movlpd_s(inst); break;
                case Iced.Intel.Mnemonic.Movlps: this.movlps_s(inst); break;
                case Iced.Intel.Mnemonic.Movmskpd: this.movmskpd_s(inst); break;
                case Iced.Intel.Mnemonic.Movmskps: this.movmskps_s(inst); break;
                case Iced.Intel.Mnemonic.Movntdq: this.movntdq_s(inst); break;
                case Iced.Intel.Mnemonic.Movnti: this.movnti_s(inst); break;
                case Iced.Intel.Mnemonic.Movntpd: this.movntpd_s(inst); break;
                case Iced.Intel.Mnemonic.Movntps: this.movntps_s(inst); break;
                case Iced.Intel.Mnemonic.Movntq: this.movntq_s(inst); break;
                case Iced.Intel.Mnemonic.Movq2dq: this.movq2dq_s(inst); break;
                case Iced.Intel.Mnemonic.Movq: this.movq_s(inst); break;
                case Iced.Intel.Mnemonic.Movsb: this.movsb_s(inst); break;
                case Iced.Intel.Mnemonic.Movsd: this.movsd_s(inst); break;
                case Iced.Intel.Mnemonic.Movshdup: this.movshdup_s(inst); break;
                case Iced.Intel.Mnemonic.Movsldup: this.movsldup_s(inst); break;
                case Iced.Intel.Mnemonic.Movupd: this.movupd_s(inst); break;
                case Iced.Intel.Mnemonic.Movups: this.movups_s(inst); break;
                case Iced.Intel.Mnemonic.Movss: this.movss_s(inst); break;
                case Iced.Intel.Mnemonic.Movsq: this.movsq_s(inst); break;
                case Iced.Intel.Mnemonic.Movsw: this.movsw_s(inst); break;
                case Iced.Intel.Mnemonic.Movsx: this.movsx_s(inst); break;
                case Iced.Intel.Mnemonic.Movsxd: this.movsxd_s(inst); break;
                case Iced.Intel.Mnemonic.Movzx: this.movzx_s(inst); break;
                case Iced.Intel.Mnemonic.Mul: this.mul_s(inst); break;
                case Iced.Intel.Mnemonic.Mulx: this.mulx_s(inst); break;
                case Iced.Intel.Mnemonic.Neg: this.neg_s(inst); break;
                case Iced.Intel.Mnemonic.Nop: this.nop_s(inst); break;
                case Iced.Intel.Mnemonic.Not: this.not_s(inst); break;
                case Iced.Intel.Mnemonic.Or: this.or_s(inst); break;
                case Iced.Intel.Mnemonic.Orpd: this.orpd_s(inst); break;
                case Iced.Intel.Mnemonic.Orps: this.orps_s(inst); break;
                case Iced.Intel.Mnemonic.Packuswb: this.packuswb_s(inst); break;
                case Iced.Intel.Mnemonic.Paddb: this.paddb_s(inst); break;
                case Iced.Intel.Mnemonic.Paddd: this.paddd_s(inst); break;
                case Iced.Intel.Mnemonic.Paddq: this.paddq_s(inst); break;
                case Iced.Intel.Mnemonic.Paddw: this.paddw_s(inst); break;
                case Iced.Intel.Mnemonic.Palignr: this.palignr_s(inst); break;
                case Iced.Intel.Mnemonic.Pand: this.pand_s(inst); break;
                case Iced.Intel.Mnemonic.Pandn: this.pandn_s(inst); break;
                case Iced.Intel.Mnemonic.Pause: this.pause_s(inst); break;
                case Iced.Intel.Mnemonic.Pavgb: this.pavgb_s(inst); break;
                case Iced.Intel.Mnemonic.Pavgw: this.pavgw_s(inst); break;
                case Iced.Intel.Mnemonic.Pcmpeqb: this.pcmpeqb_s(inst); break;
                case Iced.Intel.Mnemonic.Pcmpeqd: this.pcmpeqd_s(inst); break;
                case Iced.Intel.Mnemonic.Pcmpeqw: this.pcmpeqw_s(inst); break;
                case Iced.Intel.Mnemonic.Pcmpgtb: this.pcmpgtb_s(inst); break;
                case Iced.Intel.Mnemonic.Pcmpgtd: this.pcmpgtd_s(inst); break;
                case Iced.Intel.Mnemonic.Pcmpgtw: this.pcmpgtw_s(inst); break;
                case Iced.Intel.Mnemonic.Pextrb: this.pextrb_s(inst); break;
                case Iced.Intel.Mnemonic.Pextrd: this.pextrd_s(inst); break;
                case Iced.Intel.Mnemonic.Pextrq: this.pextrq_s(inst); break;
                case Iced.Intel.Mnemonic.Pextrw: this.pextrw_s(inst); break;
                case Iced.Intel.Mnemonic.Pinsrb: this.pinsrb_s(inst); break;
                case Iced.Intel.Mnemonic.Pinsrd: this.pinsrd_s(inst); break;
                case Iced.Intel.Mnemonic.Pinsrq: this.pinsrq_s(inst); break;
                case Iced.Intel.Mnemonic.Pinsrw: this.pinsrw_s(inst); break;
                case Iced.Intel.Mnemonic.Pmaxsb: this.pmaxsb_s(inst); break;
                case Iced.Intel.Mnemonic.Pmaxsd: this.pmaxsd_s(inst); break;
                case Iced.Intel.Mnemonic.Pmaxsw: this.pmaxsw_s(inst); break;
                case Iced.Intel.Mnemonic.Pmaxub: this.pmaxub_s(inst); break;
                case Iced.Intel.Mnemonic.Pmaxud: this.pmaxud_s(inst); break;
                case Iced.Intel.Mnemonic.Pmaxuw: this.pmaxuw_s(inst); break;
                case Iced.Intel.Mnemonic.Pminsb: this.pminsb_s(inst); break;
                case Iced.Intel.Mnemonic.Pminsd: this.pminsd_s(inst); break;
                case Iced.Intel.Mnemonic.Pminsw: this.pminsw_s(inst); break;
                case Iced.Intel.Mnemonic.Pminub: this.pminub_s(inst); break;
                case Iced.Intel.Mnemonic.Pminud: this.pminud_s(inst); break;
                case Iced.Intel.Mnemonic.Pminuw: this.pminuw_s(inst); break;
                case Iced.Intel.Mnemonic.Pmovmskb: this.pmovmskb_s(inst); break;
                case Iced.Intel.Mnemonic.Pmovsxbd: this.pmovsxbd_s(inst); break;
                case Iced.Intel.Mnemonic.Pmovsxbq: this.pmovsxbq_s(inst); break;
                case Iced.Intel.Mnemonic.Pmovsxbw: this.pmovsxbw_s(inst); break;
                case Iced.Intel.Mnemonic.Pmovsxdq: this.pmovsxdq_s(inst); break;
                case Iced.Intel.Mnemonic.Pmovsxwd: this.pmovsxwd_s(inst); break;
                case Iced.Intel.Mnemonic.Pmovsxwq: this.pmovsxwq_s(inst); break;
                case Iced.Intel.Mnemonic.Pmovzxbd: this.pmovzxbd_s(inst); break;
                case Iced.Intel.Mnemonic.Pmovzxbq: this.pmovzxbq_s(inst); break;
                case Iced.Intel.Mnemonic.Pmovzxbw: this.pmovzxbw_s(inst); break;
                case Iced.Intel.Mnemonic.Pmovzxdq: this.pmovzxdq_s(inst); break;
                case Iced.Intel.Mnemonic.Pmovzxwd: this.pmovzxwd_s(inst); break;
                case Iced.Intel.Mnemonic.Pmovzxwq: this.pmovzxwq_s(inst); break;
                case Iced.Intel.Mnemonic.Pop: this.pop_s(inst); break;
                case Iced.Intel.Mnemonic.Popa: this.popal_s(inst); break;
                case Iced.Intel.Mnemonic.Popf: this.popf_s(inst); break;
                case Iced.Intel.Mnemonic.Popfd: this.popfd_s(inst); break;
                case Iced.Intel.Mnemonic.Popfq: this.popfq_s(inst); break;
                case Iced.Intel.Mnemonic.Por: this.por_s(inst); break;
                case Iced.Intel.Mnemonic.Prefetch: this.prefetchx_s(inst); break;
                case Iced.Intel.Mnemonic.Prefetchnta: this.prefetchx_s(inst); break;
                case Iced.Intel.Mnemonic.Prefetcht0: this.prefetchx_s(inst); break;
                case Iced.Intel.Mnemonic.Prefetcht1: this.prefetchx_s(inst); break;
                case Iced.Intel.Mnemonic.Prefetcht2: this.prefetchx_s(inst); break;
                case Iced.Intel.Mnemonic.Prefetchw: this.prefetchx_s(inst); break;
                case Iced.Intel.Mnemonic.Pshufd: this.pshufd_s(inst); break;
                case Iced.Intel.Mnemonic.Pshufhw: this.pshufhw_s(inst); break;
                case Iced.Intel.Mnemonic.Pshuflw: this.pshuflw_s(inst); break;
                case Iced.Intel.Mnemonic.Pshufw: this.pshufw_s(inst); break;
                case Iced.Intel.Mnemonic.Pslld: this.pslld_s(inst); break;
                case Iced.Intel.Mnemonic.Pslldq: this.pslldq_s(inst); break;
                case Iced.Intel.Mnemonic.Psllq: this.psllq_s(inst); break;
                case Iced.Intel.Mnemonic.Psllw: this.psllw_s(inst); break;
                case Iced.Intel.Mnemonic.Psrldq: this.psrldq_s(inst); break;
                case Iced.Intel.Mnemonic.Psubb: this.psubb_s(inst); break;
                case Iced.Intel.Mnemonic.Psubd: this.psubd_s(inst); break;
                case Iced.Intel.Mnemonic.Psubq: this.psubq_s(inst); break;
                case Iced.Intel.Mnemonic.Psubw: this.psubw_s(inst); break;
                case Iced.Intel.Mnemonic.Ptest: this.ptest_s(inst); break;
                case Iced.Intel.Mnemonic.Punpckhbw: this.punpckhbw_s(inst); break;
                case Iced.Intel.Mnemonic.Punpckhdq: this.punpckhdq_s(inst); break;
                case Iced.Intel.Mnemonic.Punpckhqdq: this.punpckhqdq_s(inst); break;
                case Iced.Intel.Mnemonic.Punpckhwd: this.punpckhwd_s(inst); break;
                case Iced.Intel.Mnemonic.Punpcklbw: this.punpcklbw_s(inst); break;
                case Iced.Intel.Mnemonic.Punpckldq: this.punpckldq_s(inst); break;
                case Iced.Intel.Mnemonic.Punpcklqdq: this.punpcklqdq_s(inst); break;
                case Iced.Intel.Mnemonic.Punpcklwd: this.punpcklwd_s(inst); break;
                case Iced.Intel.Mnemonic.Push: this.push_s(inst); break;
                case Iced.Intel.Mnemonic.Pusha: this.pushal_s(inst); break;
                case Iced.Intel.Mnemonic.Pushfd: this.pushfd_s(inst); break;
                case Iced.Intel.Mnemonic.Pushfq: this.pushfq_s(inst); break;
                case Iced.Intel.Mnemonic.Pxor: this.pxor_s(inst); break;
                case Iced.Intel.Mnemonic.Rcl: this.rcl_s(inst); break;
                case Iced.Intel.Mnemonic.Rcr: this.rcr_s(inst); break;
                case Iced.Intel.Mnemonic.Rdtsc: this.rdtsc_s(inst); break;
                case Iced.Intel.Mnemonic.Ret: this.ret_s(inst); break;
                case Iced.Intel.Mnemonic.Rol: this.rol_s(inst); break;
                case Iced.Intel.Mnemonic.Ror: this.ror_s(inst); break;
                case Iced.Intel.Mnemonic.Rorx: this.rorx_s(inst); break;
                case Iced.Intel.Mnemonic.Sahf: this.sahf_s(inst); break;
                case Iced.Intel.Mnemonic.Sal: this.shl_s(inst); break;
                case Iced.Intel.Mnemonic.Sar: this.sar_s(inst); break;
                case Iced.Intel.Mnemonic.Sarx: this.sarx_s(inst); break;
                case Iced.Intel.Mnemonic.Sbb: this.sbb_s(inst); break;
                case Iced.Intel.Mnemonic.Scasb: this.scasb_s(inst); break;
                case Iced.Intel.Mnemonic.Scasd: this.scasd_s(inst); break;
                case Iced.Intel.Mnemonic.Scasq: this.scasq_s(inst); break;
                case Iced.Intel.Mnemonic.Scasw: this.scasw_s(inst); break;
                case Iced.Intel.Mnemonic.Seta: this.seta_s(inst); break;
                case Iced.Intel.Mnemonic.Setae: this.setae_s(inst); break;
                case Iced.Intel.Mnemonic.Setb: this.setb_s(inst); break;
                case Iced.Intel.Mnemonic.Setbe: this.setbe_s(inst); break;
                case Iced.Intel.Mnemonic.Sete: this.sete_s(inst); break;
                case Iced.Intel.Mnemonic.Setg: this.setg_s(inst); break;
                case Iced.Intel.Mnemonic.Setge: this.setge_s(inst); break;
                case Iced.Intel.Mnemonic.Setl: this.setl_s(inst); break;
                case Iced.Intel.Mnemonic.Setle: this.setle_s(inst); break;
                case Iced.Intel.Mnemonic.Setne: this.setne_s(inst); break;
                case Iced.Intel.Mnemonic.Setno: this.setno_s(inst); break;
                case Iced.Intel.Mnemonic.Setnp: this.setnp_s(inst); break;
                case Iced.Intel.Mnemonic.Setns: this.setns_s(inst); break;
                case Iced.Intel.Mnemonic.Seto: this.seto_s(inst); break;
                case Iced.Intel.Mnemonic.Setp: this.setp_s(inst); break;
                case Iced.Intel.Mnemonic.Sets: this.sets_s(inst); break;
                case Iced.Intel.Mnemonic.Sfence: this.sfence_s(inst); break;
                case Iced.Intel.Mnemonic.Shl: this.shl_s(inst); break;
                case Iced.Intel.Mnemonic.Shld: this.shld_s(inst); break;
                case Iced.Intel.Mnemonic.Shlx: this.shlx_s(inst); break;
                case Iced.Intel.Mnemonic.Shr: this.shr_s(inst); break;
                case Iced.Intel.Mnemonic.Shrd: this.shrd_s(inst); break;
                case Iced.Intel.Mnemonic.Shrx: this.shrx_s(inst); break;
                case Iced.Intel.Mnemonic.Stc: this.stc_s(inst); break;
                case Iced.Intel.Mnemonic.Std: this.std_s(inst); break;
                case Iced.Intel.Mnemonic.Sti: this.sti_s(inst); break;
                case Iced.Intel.Mnemonic.Stmxcsr: this.stmxcsr_s(inst); break;
                case Iced.Intel.Mnemonic.Stosb: this.stosb_s(inst); break;
                case Iced.Intel.Mnemonic.Stosd: this.stosd_s(inst); break;
                case Iced.Intel.Mnemonic.Stosq: this.stosq_s(inst); break;
                case Iced.Intel.Mnemonic.Stosw: this.stosw_s(inst); break;
                case Iced.Intel.Mnemonic.Sub: this.sub_s(inst); break;
                case Iced.Intel.Mnemonic.Syscall: this.syscall_s(inst); break;
                case Iced.Intel.Mnemonic.Sysenter: this.sysenter_s(inst); break;
                case Iced.Intel.Mnemonic.Test: this.test_s(inst); break;
                case Iced.Intel.Mnemonic.Tzcnt: this.tzcnt_s(inst); break;
                case Iced.Intel.Mnemonic.Unpckhpd: this.unpckhpd_s(inst); break;
                case Iced.Intel.Mnemonic.Unpckhps: this.unpckhps_s(inst); break;
                case Iced.Intel.Mnemonic.Unpcklpd: this.unpcklpd_s(inst); break;
                case Iced.Intel.Mnemonic.Unpcklps: this.unpcklps_s(inst); break;
                case Iced.Intel.Mnemonic.Vmovd: this.vmovd_s(inst); break;
                case Iced.Intel.Mnemonic.Vmovdqa: this.vmovdqa_s(inst); break;
                case Iced.Intel.Mnemonic.Vmovdqu: this.vmovdqu_s(inst); break;
                case Iced.Intel.Mnemonic.Vmovq: this.vmovq_s(inst); break;
                case Iced.Intel.Mnemonic.Vmovsd: this.vmovsd_s(inst); break;
                case Iced.Intel.Mnemonic.Vmovaps: this.vmovaps_s(inst); break;
                case Iced.Intel.Mnemonic.Vmovups: this.vmovups_s(inst); break;
                case Iced.Intel.Mnemonic.Vpand: this.vpand_s(inst); break;
                case Iced.Intel.Mnemonic.Vpandn: this.vpandn_s(inst); break;
                case Iced.Intel.Mnemonic.Vpextrb: this.vpextrb_s(inst); break;
                case Iced.Intel.Mnemonic.Vpextrd: this.vpextrd_s(inst); break;
                case Iced.Intel.Mnemonic.Vpextrq: this.vpextrq_s(inst); break;
                case Iced.Intel.Mnemonic.Vpextrw: this.vpextrw_s(inst); break;
                case Iced.Intel.Mnemonic.Vpbroadcastb: this.vpbroadcastb_s(inst); break;
                case Iced.Intel.Mnemonic.Vpcmpeqb: this.vpcmpeqb_s(inst); break;
                case Iced.Intel.Mnemonic.Vpcmpeqd: this.vpcmpeqd_s(inst); break;
                case Iced.Intel.Mnemonic.Vpcmpeqq: this.vpcmpeqq_s(inst); break;
                case Iced.Intel.Mnemonic.Vpcmpeqw: this.vpcmpeqw_s(inst); break;
                case Iced.Intel.Mnemonic.Vpcmpgtb: this.vpcmpgtb_s(inst); break;
                case Iced.Intel.Mnemonic.Vpcmpgtd: this.vpcmpgtd_s(inst); break;
                case Iced.Intel.Mnemonic.Vpcmpgtw: this.vpcmpgtw_s(inst); break;
                case Iced.Intel.Mnemonic.Vpmovmskb: this.vpmovmskb_s(inst); break;
                case Iced.Intel.Mnemonic.Vpminub: this.vpminub_s(inst); break;
                case Iced.Intel.Mnemonic.Vpor: this.vpor_s(inst); break;
                case Iced.Intel.Mnemonic.Vpshufd: this.vpshufd_s(inst); break;
                case Iced.Intel.Mnemonic.Vpslldq: this.vpslldq_s(inst); break;
                case Iced.Intel.Mnemonic.Vpsubb: this.vpsubb_s(inst); break;
                case Iced.Intel.Mnemonic.Vpsubd: this.vpsubd_s(inst); break;
                case Iced.Intel.Mnemonic.Vpsubq: this.vpsubq_s(inst); break;
                case Iced.Intel.Mnemonic.Vpsubw: this.vpsubw_s(inst); break;
                case Iced.Intel.Mnemonic.Vptest: this.vptest_s(inst); break;
                case Iced.Intel.Mnemonic.Vpxor: this.vpxor_s(inst); break;
                case Iced.Intel.Mnemonic.Vxorps: this.vxorps_s(inst); break;
                case Iced.Intel.Mnemonic.Wait: this.wait_s(inst); break;
                case Iced.Intel.Mnemonic.Wbinvd: this.wbinvd_s(inst); break;
                case Iced.Intel.Mnemonic.Xadd: this.xadd_s(inst); break;
                case Iced.Intel.Mnemonic.Xchg: this.xchg_s(inst); break;
                case Iced.Intel.Mnemonic.Xor: this.xor_s(inst); break;
                case Iced.Intel.Mnemonic.Xorpd: this.xorpd_s(inst); break;
                case Iced.Intel.Mnemonic.Xorps: this.xorps_s(inst); break;
                default:
                    throw new InvalidOperationException($"Instruction {inst.Type} at address 0x{inst.Address.ToString("X")} is not supported.");
            }
            return true;
        }


        AbstractNode alignAddStack_s(Instruction inst, uint delta)
        {
            var dst = new OperandWrapper(this.architecture.GetStackPointer());

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astCtxt.bv(delta, dst.BitSize);

            /* Create the semantics */
            var node = this.astCtxt.bvadd(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "Stack alignment");

            /* Return the new stack value */
            return op1;
        }


        AbstractNode alignSubStack_s(Instruction inst, uint delta)
        {
            var dst = new OperandWrapper(this.architecture.GetStackPointer());

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astCtxt.bv(delta, dst.BitSize);

            /* Create the semantics */
            var node = this.astCtxt.bvsub(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "Stack alignment");

            // Note(Colton): In Triton, they return a concrete evaluation of the stack pointer from this function.
            // However, since we introduce symbolic memory, and the above method call stores an update to the stack pointer,
            // we want to return an abstract node containing only RegisterNode(RSP).
            // This is extremely confusing, but without this change on our part, the RSP register will be decremented twice,
            // causing the translation to be incorrect.
            return op1;
        }


        void clearFlag_s(Instruction inst, Register flag, string comment)
        {
            /* Create the semantics */
            var node = this.astCtxt.bv(0, 1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, flag, comment);

        }


        void setFlag_s(Instruction inst, Register flag, string comment)
        {
            /* Create the semantics */
            var node = this.astCtxt.bv(1, 1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, flag, comment);

        }


        void undefined_s(Instruction inst, Register reg)
        {
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, this.astCtxt.undef(reg.BitSize), reg, "Undefined operation");
        }


        void controlFlow_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var counter = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            switch (inst.Prefix)
            {

                case Prefix.ID_PREFIX_REP:
                    {
                        /* Create symbolic operands */
                        var op1 = this.astBuilder.GetOperandAst(inst, counter);

                        /* Create the semantics for Counter */
                        var node1 = this.astCtxt.ite(
                                       this.astCtxt.equal(op1, this.astCtxt.bv(0, counter.BitSize)),
                                       op1,
                                       this.astCtxt.bvsub(op1, this.astCtxt.bv(1, counter.BitSize))
                                     );

                        /* Create the semantics for PC */
                        var node2 = this.astCtxt.ite(
                                       this.astCtxt.equal(node1, this.astCtxt.bv(0, counter.BitSize)),
                                       this.astCtxt.bv(inst.NextAddress, pc.BitSize),
                                       this.astCtxt.bv(inst.Address, pc.BitSize)
                                     );

                        /* Create symbolic expression */
                        var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, counter, "Counter operation");
                        var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, pc, "Program Counter");

                        break;
                    }

                case Prefix.ID_PREFIX_REPE:
                    {
                        /* Create symbolic operands */
                        var op1 = this.astBuilder.GetOperandAst(inst, counter);
                        var op2 = this.astBuilder.GetOperandAst(inst, zf);

                        /* Create the semantics for Counter */
                        var node1 = this.astCtxt.ite(
                                       this.astCtxt.equal(op1, this.astCtxt.bv(0, counter.BitSize)),
                                       op1,
                                       this.astCtxt.bvsub(op1, this.astCtxt.bv(1, counter.BitSize))
                                     );

                        /* Create the semantics for PC */
                        var node2 = this.astCtxt.ite(
                                       this.astCtxt.lor(
                                         this.astCtxt.equal(node1, this.astCtxt.bv(0, counter.BitSize)),
                                         this.astCtxt.equal(op2, this.astCtxt.bvfalse())
                                       ),
                                       this.astCtxt.bv(inst.NextAddress, pc.BitSize),
                                       this.astCtxt.bv(inst.Address, pc.BitSize)
                                     );

                        /* Create symbolic expression */
                        var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, counter, "Counter operation");
                        var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, pc, "Program Counter");

                        break;
                    }

                case Prefix.ID_PREFIX_REPNE:
                    {
                        /* Create symbolic operands */
                        var op1 = this.astBuilder.GetOperandAst(inst, counter);
                        var op2 = this.astBuilder.GetOperandAst(inst, zf);

                        /* Create the semantics for Counter */
                        var node1 = this.astCtxt.ite(
                                       this.astCtxt.equal(op1, this.astCtxt.bv(0, counter.BitSize)),
                                       op1,
                                       this.astCtxt.bvsub(op1, this.astCtxt.bv(1, counter.BitSize))
                                     );

                        /* Create the semantics for PC */
                        var node2 = this.astCtxt.ite(
                                       this.astCtxt.lor(
                                         this.astCtxt.equal(node1, this.astCtxt.bv(0, counter.BitSize)),
                                         this.astCtxt.equal(op2, this.astCtxt.bvtrue())
                                       ),
                                       this.astCtxt.bv(inst.NextAddress, pc.BitSize),
                                       this.astCtxt.bv(inst.Address, pc.BitSize)
                                     );

                        /* Create symbolic expression */
                        var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, counter, "Counter operation");
                        var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, pc, "Program Counter");

                        break;
                    }

                default:
                    {
                        /* Create the semantics */
                        var node = this.astCtxt.bv(inst.NextAddress, pc.BitSize);

                        /* Create symbolic expression */
                        var expr = this.ExpressionDatabase.StoreSymbolicRegisterAssignment(inst, node, this.architecture.GetProgramCounter(), "Program Counter");

                        break;
                    }
            }
        }


        void af_s(Instruction inst,
                                AbstractNode parent,
                                OperandWrapper dst,
                                AbstractNode op1,
                                AbstractNode op2,
                                bool vol = false)
        {
            return;
            var bvSize = dst.BitSize;
            var low = vol ? 0 : dst.Low;
            var high = vol ? bvSize - 1 : dst.High;

            /*
             * Create the semantic.
             * af = 0x10 == (0x10 & (regDst ^ op1 ^ op2))
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            this.astCtxt.bv(0x10, bvSize),
                            this.astCtxt.bvand(
                              this.astCtxt.bv(0x10, bvSize),
                              this.astCtxt.bvxor(
                                this.astCtxt.extract(high, low, this.astCtxt.reference(parent)),
                                this.astCtxt.bvxor(op1, op2)
                              )
                            )
                          ),
                          this.astCtxt.bv(1, 1),
                          this.astCtxt.bv(0, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_AF), "Adjust flag");

        }


        void afAaa_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   AbstractNode op3,
                                   bool vol = false)
        {

            var bvSize = dst.BitSize;

            /*
             * Create the semantic.
             * af = 1 if ((AL AND 0FH) > 9) or (AF = 1) then 0
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.lor(
                            this.astCtxt.bvugt(
                              this.astCtxt.bvand(op1, this.astCtxt.bv(0xf, bvSize)),
                              this.astCtxt.bv(9, bvSize)
                            ),
                            this.astCtxt.equal(op3, this.astCtxt.bvtrue())
                          ),
                          this.astCtxt.bv(1, 1),
                          this.astCtxt.bv(0, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_AF), "Adjust flag");

        }


        void afNeg_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   bool vol = false)
        {

            var bvSize = dst.BitSize;
            var low = vol ? 0 : dst.Low;
            var high = vol ? bvSize - 1 : dst.High;

            /*
             * Create the semantic.
             * af = 0x10 == (0x10 & (op1 ^ regDst))
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            this.astCtxt.bv(0x10, bvSize),
                            this.astCtxt.bvand(
                              this.astCtxt.bv(0x10, bvSize),
                              this.astCtxt.bvxor(
                                op1,
                                this.astCtxt.extract(high, low, this.astCtxt.reference(parent))
                              )
                            )
                          ),
                          this.astCtxt.bv(1, 1),
                          this.astCtxt.bv(0, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_AF), "Adjust flag");

        }


        void cfAaa_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   AbstractNode op3,
                                   bool vol = false)
        {

            var bvSize = dst.BitSize;

            /*
             * Create the semantic.
             * cf = 1 if ((AL AND 0FH) > 9) or (AF = 1) then 0
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.lor(
                            this.astCtxt.bvugt(
                              this.astCtxt.bvand(op1, this.astCtxt.bv(0xf, bvSize)),
                              this.astCtxt.bv(9, bvSize)
                            ),
                            this.astCtxt.equal(op3, this.astCtxt.bvtrue())
                          ),
                          this.astCtxt.bv(1, 1),
                          this.astCtxt.bv(0, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Carry flag");

        }


        void cfAdd_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            var bvSize = dst.BitSize;
            var low = vol ? 0 : dst.Low;
            var high = vol ? bvSize - 1 : dst.High;

            /*
             * Create the semantic.
             * cf = MSB((op1 & op2) ^ ((op1 ^ op2 ^ parent) & (op1 ^ op2)));
             */
            var node = this.astCtxt.extract(bvSize - 1, bvSize - 1,
                          this.astCtxt.bvxor(
                            this.astCtxt.bvand(op1, op2),
                            this.astCtxt.bvand(
                              this.astCtxt.bvxor(
                                this.astCtxt.bvxor(op1, op2),
                                this.astCtxt.extract(high, low, this.astCtxt.reference(parent))
                              ),
                            this.astCtxt.bvxor(op1, op2))
                          )
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Carry flag");

        }


        void cfBlsi_s(Instruction inst,
                                    AbstractNode parent,
                                    OperandWrapper dst,
                                    AbstractNode op1,
                                    bool vol = false)
        {

            /*
             * Create the semantic.
             * cf = 0 if op1 == 0 else 1
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            op1,
                            this.astCtxt.bv(0, dst.BitSize)
                          ),
                          this.astCtxt.bv(0, 1),
                          this.astCtxt.bv(1, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Carry flag");

        }


        void cfBlsmsk_s(Instruction inst,
                                      AbstractNode parent,
                                      OperandWrapper dst,
                                      AbstractNode op1,
                                      bool vol = false)
        {

            /*
             * Create the semantic.
             * cf = 1 if op1 == 0 else 0
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            op1,
                            this.astCtxt.bv(0, dst.BitSize)
                          ),
                          this.astCtxt.bv(1, 1),
                          this.astCtxt.bv(0, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Carry flag");

        }


        void cfBlsr_s(Instruction inst,
                                    AbstractNode parent,
                                    OperandWrapper dst,
                                    AbstractNode op1,
                                    bool vol = false)
        {

            /*
             * Create the semantic.
             * cf = 1 if op1 == 0 else 0
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            op1,
                            this.astCtxt.bv(0, dst.BitSize)
                          ),
                          this.astCtxt.bv(1, 1),
                          this.astCtxt.bv(0, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Carry flag");

        }


        void cfImul_s(Instruction inst,
                                    AbstractNode parent,
                                    OperandWrapper dst,
                                    AbstractNode op1,
                                    AbstractNode res,
                                    bool vol = false)
        {

            /*
             * Create the semantic.
             * cf = 0 if sx(dst) == node else 1
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            this.astCtxt.sx(dst.BitSize, op1),
                            res
                          ),
                          this.astCtxt.bv(0, 1),
                          this.astCtxt.bv(1, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Carry flag");

        }


        void cfLzcnt_s(Instruction inst,
                                     AbstractNode parent,
                                     OperandWrapper src,
                                     AbstractNode op1,
                                     bool vol = false)
        {

            var bvSize = src.BitSize;
            var low = vol ? 0 : src.Low;
            var high = vol ? bvSize - 1 : src.High;

            /*
             * Create the semantic.
             * cf = 0 == parent
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            this.astCtxt.extract(high, low, op1),
                            this.astCtxt.bv(0, bvSize)
                          ),
                          this.astCtxt.bv(1, 1),
                          this.astCtxt.bv(0, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Carry flag");

        }


        void cfMul_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   bool vol = false)
        {

            /*
             * Create the semantic.
             * cf = 0 if op1 == 0 else 1
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            op1,
                            this.astCtxt.bv(0, dst.BitSize)
                          ),
                          this.astCtxt.bv(0, 1),
                          this.astCtxt.bv(1, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Carry flag");

        }


        void cfNeg_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   bool vol = false)
        {

            /*
             * Create the semantic.
             * cf = 0 if op1 == 0 else 1
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            op1,
                            this.astCtxt.bv(0, dst.BitSize)
                          ),
                          this.astCtxt.bv(0, 1),
                          this.astCtxt.bv(1, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Carry flag");

        }


        void cfPtest_s(Instruction inst,
                                     AbstractNode parent,
                                     OperandWrapper dst,
                                     bool vol = false)
        {

            var bvSize = dst.BitSize;
            var low = vol ? 0 : dst.Low;
            var high = vol ? bvSize - 1 : dst.High;

            /*
             * Create the semantic.
             * cf = 0 == regDst
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            this.astCtxt.extract(high, low, this.astCtxt.reference(parent)),
                            this.astCtxt.bv(0, bvSize)
                          ),
                          this.astCtxt.bv(1, 1),
                          this.astCtxt.bv(0, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Carry flag");

        }


        void cfRcl_s(Instruction inst,
                                   AbstractNode parent,
                                   AbstractNode result,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            var bvSize = op2.BitvectorSize;
            var high = result.BitvectorSize - 1;
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize)),
                          this.astBuilder.GetOperandAst(cf),
                          this.astCtxt.extract(high, high, result)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, cf.Register, "Carry flag");

        }


        void cfRcr_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode result,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            var bvSize = op2.BitvectorSize;
            var high = result.BitvectorSize - 1;
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize)),
                          this.astBuilder.GetOperandAst(cf),
                          this.astCtxt.extract(high, high, result) /* yes it's should be LSB, but here it's a trick :-) */
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, cf.Register, "Carry flag");

        }


        void cfRol_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            var bvSize = op2.BitvectorSize;
            var low = vol ? 0 : dst.Low;
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize)),
                          this.astBuilder.GetOperandAst(cf),
                          this.astCtxt.extract(low, low, this.astCtxt.reference(parent))
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, cf.Register, "Carry flag");

        }


        void cfRor_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            var bvSize = op2.BitvectorSize;
            var high = vol ? bvSize - 1 : dst.High;
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize)),
                          this.astBuilder.GetOperandAst(cf),
                          this.astCtxt.extract(high, high, this.astCtxt.reference(parent))
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, cf.Register, "Carry flag");

        }


        void cfSar_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   AbstractNode op2,
                                   bool vol = false)
        {
            return;
            var bvSize = dst.BitSize;
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /*
             * Create the semantic.
             * if op2 != 0:
             *   if op2 > bvSize:
             *     cf.id = ((op1 >> (bvSize - 1)) & 1)
             *   else:
             *     cf.id = ((op1 >> (op2 - 1)) & 1)
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize)),
                          this.astBuilder.GetOperandAst(cf),
                          this.astCtxt.ite(
                            this.astCtxt.bvugt(op2, this.astCtxt.bv(bvSize, bvSize)),
                            this.astCtxt.extract(0, 0, this.astCtxt.bvlshr(op1, this.astCtxt.bvsub(this.astCtxt.bv(bvSize, bvSize), this.astCtxt.bv(1, bvSize)))),
                            this.astCtxt.extract(0, 0, this.astCtxt.bvlshr(op1, this.astCtxt.bvsub(op2, this.astCtxt.bv(1, bvSize))))
                          )
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, cf.Register, "Carry flag");

        }


        void cfShl_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            var bvSize = dst.BitSize;
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /*
             * Create the semantic.
             * cf = (op1 >> ((bvSize - op2) & 1) if op2 != 0
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize)),
                          this.astBuilder.GetOperandAst(cf),
                          this.astCtxt.extract(0, 0,
                            this.astCtxt.bvlshr(
                              op1,
                              this.astCtxt.bvsub(
                                this.astCtxt.bv(bvSize, bvSize),
                                op2
                              )
                            )
                          )
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, cf.Register, "Carry flag");
        }


        void cfShld_s(Instruction inst,
                                    AbstractNode parent,
                                    OperandWrapper dst,
                                    AbstractNode op1,
                                    AbstractNode op2,
                                    AbstractNode op3,
                                    bool vol = false)
        {

            var bv1Size = op1.BitvectorSize;
            var bv2Size = op2.BitvectorSize;
            var bv3Size = op3.BitvectorSize;
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /*
             * Create the semantic.
             * cf = MSB(rol(op3, concat(op2,op1))) if op3 != 0
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op3, this.astCtxt.bv(0, bv3Size)),
                          this.astBuilder.GetOperandAst(cf),
                          this.astCtxt.extract(
                            dst.BitSize, dst.BitSize,
                            this.astCtxt.bvrol(
                              this.astCtxt.concat(op2, op1),
                              this.astCtxt.zx(((bv1Size + bv2Size) - bv3Size), op3)
                            )
                          )
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, cf.Register, "Carry flag");

        }


        void cfShr_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            var bvSize = dst.BitSize;
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /*
             * Create the semantic.
             * cf = ((op1 >> (op2 - 1)) & 1) if op2 != 0
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize)),
                          this.astBuilder.GetOperandAst(cf),
                          this.astCtxt.extract(0, 0,
                            this.astCtxt.bvlshr(
                              op1,
                              this.astCtxt.bvsub(
                                op2,
                                this.astCtxt.bv(1, bvSize))
                            )
                          )
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, cf.Register, "Carry flag");

        }


        void cfShrd_s(Instruction inst,
                                    AbstractNode parent,
                                    OperandWrapper dst,
                                    AbstractNode op1,
                                    AbstractNode op2,
                                    AbstractNode op3,
                                    bool vol = false)
        {

            var bvSize = dst.BitSize;
            var bv1Size = op1.BitvectorSize;
            var bv2Size = op2.BitvectorSize;
            var bv3Size = op3.BitvectorSize;
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /*
             * Create the semantic.
             * cf = MSB(ror(op3, concat(op2,op1))) if op3 != 0
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op3, this.astCtxt.bv(0, bv3Size)),
                          this.astBuilder.GetOperandAst(cf),
                          this.astCtxt.extract(
                            (bvSize * 2) - 1, (bvSize * 2) - 1,
                            this.astCtxt.bvror(
                              this.astCtxt.concat(op2, op1),
                              this.astCtxt.zx(((bv1Size + bv2Size) - bv3Size), op3)
                            )
                          )
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, cf.Register, "Carry flag");

        }


        void cfSub_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   AbstractNode op2,
                                   bool vol = false)
        {
            return;
            var bvSize = dst.BitSize;
            var low = vol ? 0 : dst.Low;
            var high = vol ? bvSize - 1 : dst.High;

            /*
             * Create the semantic.
             * cf = extract(bvSize, bvSize (((op1 ^ op2 ^ res) ^ ((op1 ^ res) & (op1 ^ op2)))))
             */
            var node = this.astCtxt.extract(bvSize - 1, bvSize - 1,
                          this.astCtxt.bvxor(
                            this.astCtxt.bvxor(op1, this.astCtxt.bvxor(op2, this.astCtxt.extract(high, low, this.astCtxt.reference(parent)))),
                            this.astCtxt.bvand(
                              this.astCtxt.bvxor(op1, this.astCtxt.extract(high, low, this.astCtxt.reference(parent))),
                              this.astCtxt.bvxor(op1, op2)
                            )
                          )
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Carry flag");

        }


        void cfTzcnt_s(Instruction inst,
                                     AbstractNode parent,
                                     OperandWrapper src,
                                     AbstractNode op1,
                                     bool vol = false)
        {

            var bvSize = src.BitSize;
            var low = vol ? 0 : src.Low;
            var high = vol ? bvSize - 1 : src.High;

            /*
             * Create the semantic.
             * cf = 0 == parent
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            this.astCtxt.extract(high, low, op1),
                            this.astCtxt.bv(0, bvSize)
                          ),
                          this.astCtxt.bv(1, 1),
                          this.astCtxt.bv(0, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Carry flag");

        }


        void ofAdd_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            var bvSize = dst.BitSize;
            var low = vol ? 0 : dst.Low;
            var high = vol ? bvSize - 1 : dst.High;

            /*
             * Create the semantic.
             * of = MSB((op1 ^ ~op2) & (op1 ^ regDst))
             */
            var node = this.astCtxt.extract(bvSize - 1, bvSize - 1,
                          this.astCtxt.bvand(
                            this.astCtxt.bvxor(op1, this.astCtxt.bvnot(op2)),
                            this.astCtxt.bvxor(op1, this.astCtxt.extract(high, low, this.astCtxt.reference(parent)))
                          )
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Overflow flag");

        }


        void ofImul_s(Instruction inst,
                                    AbstractNode parent,
                                    OperandWrapper dst,
                                    AbstractNode op1,
                                    AbstractNode res,
                                    bool vol = false)
        {
            /*
             * Create the semantic.
             * of = 0 if sx(dst) == node else 1
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            this.astCtxt.sx(dst.BitSize, op1),
                            res
                          ),
                          this.astCtxt.bv(0, 1),
                          this.astCtxt.bv(1, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Overflow flag");

        }


        void ofMul_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   bool vol = false)
        {

            /*
             * Create the semantic.
             * of = 0 if up == 0 else 1
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            op1,
                            this.astCtxt.bv(0, dst.BitSize)
                          ),
                          this.astCtxt.bv(0, 1),
                          this.astCtxt.bv(1, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Overflow flag");

        }


        void ofNeg_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   bool vol = false)
        {

            var bvSize = dst.BitSize;
            var low = vol ? 0 : dst.Low;
            var high = vol ? bvSize - 1 : dst.High;

            /*
             * Create the semantic.
             * of = (res & op1) >> (bvSize - 1) & 1
             */
            var node = this.astCtxt.extract(0, 0,
                          this.astCtxt.bvlshr(
                            this.astCtxt.bvand(this.astCtxt.extract(high, low, this.astCtxt.reference(parent)), op1),
                            this.astCtxt.bvsub(this.astCtxt.bv(bvSize, bvSize), this.astCtxt.bv(1, bvSize))
                          )
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Overflow flag");

        }


        void ofRol_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            var bvSize = dst.BitSize;
            var high = vol ? bvSize - 1 : dst.High;
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            var node = this.astCtxt.ite(
                          this.astCtxt.equal(this.astCtxt.zx(bvSize - op2.BitvectorSize, op2), this.astCtxt.bv(1, bvSize)),
                          this.astCtxt.bvxor(
                            this.astCtxt.extract(high, high, this.astCtxt.reference(parent)),
                            this.astBuilder.GetOperandAst(inst, cf)
                          ),
                          this.astBuilder.GetOperandAst(of)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, of.Register, "Overflow flag");

        }


        void ofRor_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            var bvSize = op2.BitvectorSize;
            var high = vol ? bvSize - 1 : dst.High;
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bv(1, bvSize)),
                          this.astCtxt.bvxor(
                            this.astCtxt.extract(high, high, this.astCtxt.reference(parent)),
                            this.astCtxt.extract(high - 1, high - 1, this.astCtxt.reference(parent))
                          ),
                          this.astBuilder.GetOperandAst(of)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, of.Register, "Overflow flag");

        }


        void ofRcr_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            var bvSize = op2.BitvectorSize;
            var high = dst.BitSize - 1;
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bv(1, bvSize)),
                          this.astCtxt.bvxor(
                            this.astCtxt.extract(high, high, op1),
                            this.astBuilder.GetOperandAst(inst, cf)
                          ),
                          this.astBuilder.GetOperandAst(of)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, of.Register, "Overflow flag");

        }


        void ofSar_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op2,
                                   bool vol = false)
        {
            return;
            var bvSize = dst.BitSize;
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /*
             * Create the semantic.
             * of = 0 if op2 == 1
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.land(
                            this.astCtxt.equal(
                              /* #672 */
                              this.astCtxt.reference(parent),
                              this.astCtxt.reference(parent)
                            /* ---- */
                            ),
                            this.astCtxt.equal(
                              op2,
                              this.astCtxt.bv(1, bvSize)
                            )
                          ),
                          this.astCtxt.bv(0, 1),
                          this.astBuilder.GetOperandAst(of)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, of.Register, "Overflow flag");

        }


        void ofShl_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            var bvSize = dst.BitSize;
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /*
             * Create the semantic.
             * of = ((op1 >> (bvSize - 1)) ^ (op1 >> (bvSize - 2))) & 1; if op2 == 1
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            op2,
                            this.astCtxt.bv(1, bvSize)),
                          this.astCtxt.extract(0, 0,
                            this.astCtxt.bvxor(
                              this.astCtxt.bvlshr(op1, this.astCtxt.bvsub(this.astCtxt.bv(bvSize, bvSize), this.astCtxt.bv(1, bvSize))),
                              this.astCtxt.bvlshr(op1, this.astCtxt.bvsub(this.astCtxt.bv(bvSize, bvSize), this.astCtxt.bv(2, bvSize)))
                            )
                          ),
                          this.astBuilder.GetOperandAst(of)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, of.Register, "Overflow flag");

        }


        void ofShld_s(Instruction inst,
                                    AbstractNode parent,
                                    OperandWrapper dst,
                                    AbstractNode op1,
                                    AbstractNode op2,
                                    AbstractNode op3,
                                    bool vol = false)
        {

            var bvSize = dst.BitSize;
            var bv1Size = op1.BitvectorSize;
            var bv2Size = op2.BitvectorSize;
            var bv3Size = op3.BitvectorSize;
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /*
             * Create the semantic.
             * of = MSB(rol(op3, concat(op2,op1))) ^ MSB(op1); if op3 == 1
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            this.astCtxt.zx(bvSize - bv3Size, op3),
                            this.astCtxt.bv(1, bvSize)),
                          this.astCtxt.bvxor(
                            this.astCtxt.extract(
                              bvSize - 1, bvSize - 1,
                              this.astCtxt.bvrol(
                                this.astCtxt.concat(op2, op1),
                                this.astCtxt.zx(((bv1Size + bv2Size) - bv3Size), op3)
                              )
                            ),
                            this.astCtxt.extract(bvSize - 1, bvSize - 1, op1)
                          ),
                          this.astBuilder.GetOperandAst(of)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, of.Register, "Overflow flag");

        }


        void ofShr_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            var bvSize = dst.BitSize;
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /*
             * Create the semantic.
             * of = ((op1 >> (bvSize - 1)) & 1) if op2 == 1
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            op2,
                            this.astCtxt.bv(1, bvSize)),
                          this.astCtxt.extract(0, 0, this.astCtxt.bvlshr(op1, this.astCtxt.bvsub(this.astCtxt.bv(bvSize, bvSize), this.astCtxt.bv(1, bvSize)))),
                          this.astBuilder.GetOperandAst(of)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, of.Register, "Overflow flag");

        }


        void ofShrd_s(Instruction inst,
                                    AbstractNode parent,
                                    OperandWrapper dst,
                                    AbstractNode op1,
                                    AbstractNode op2,
                                    AbstractNode op3,
                                    bool vol = false)
        {

            var bvSize = dst.BitSize;
            var bv1Size = op1.BitvectorSize;
            var bv2Size = op2.BitvectorSize;
            var bv3Size = op3.BitvectorSize;
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /*
             * Create the semantic.
             * of = MSB(ror(op3, concat(op2,op1))) ^ MSB(op1); if op3 == 1
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            this.astCtxt.zx(bvSize - op3.BitvectorSize, op3),
                            this.astCtxt.bv(1, bvSize)),
                          this.astCtxt.bvxor(
                            this.astCtxt.extract(
                              bvSize - 1, bvSize - 1,
                              this.astCtxt.bvror(
                                this.astCtxt.concat(op2, op1),
                                this.astCtxt.zx(((bv1Size + bv2Size) - bv3Size), op3)
                              )
                            ),
                            this.astCtxt.extract(dst.BitSize - 1, dst.BitSize - 1, op1)
                          ),
                          this.astBuilder.GetOperandAst(of)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, of.Register, "Overflow flag");

        }


        void ofSub_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op1,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            var bvSize = dst.BitSize;
            var low = vol ? 0 : dst.Low;
            var high = vol ? bvSize - 1 : dst.High;

            /*
             * Create the semantic.
             * of = high:bool((op1 ^ op2) & (op1 ^ regDst))
             */
            var node = this.astCtxt.extract(bvSize - 1, bvSize - 1,
                          this.astCtxt.bvand(
                            this.astCtxt.bvxor(op1, op2),
                            this.astCtxt.bvxor(op1, this.astCtxt.extract(high, low, this.astCtxt.reference(parent)))
                          )
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Overflow flag");

        }


        void pf_s(Instruction inst,
                                AbstractNode parent,
                                OperandWrapper dst,
                                bool vol = false)
        {
            return;
            var low = vol ? 0 : dst.Low;
            var high = vol ? BitSizes.Byte - 1 : low == 0 ? BitSizes.Byte - 1 : BitSizes.Word - 1;

            /*
             * Create the semantics.
             *
             * pf is set to one if there is an even number of bit set to 1 in the least
             * significant byte of the result.
             */
            var node = this.astCtxt.bv(1, 1);
            for (uint counter = 0; counter <= BitSizes.Byte - 1; counter++)
            {
                node = this.astCtxt.bvxor(
                         node,
                         this.astCtxt.extract(0, 0,
                           this.astCtxt.bvlshr(
                             this.astCtxt.extract(high, low, this.astCtxt.reference(parent)),
                             this.astCtxt.bv(counter, BitSizes.Byte)
                           )
                        )
                      );
            }

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_PF), "Parity flag");

        }


        void pfShl_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op2,
                                   bool vol = false)
        {
            return;
            var bvSize = dst.BitSize;
            var low = vol ? 0 : dst.Low;
            var high = vol ? BitSizes.Byte - 1 : low == 0 ? BitSizes.Byte - 1 : BitSizes.Word - 1;
            var pf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_PF));

            /*
             * Create the semantics.
             * pf if op2 != 0
             */
            var node1 = this.astCtxt.bv(1, 1);
            for (uint counter = 0; counter <= BitSizes.Byte - 1; counter++)
            {
                node1 = this.astCtxt.bvxor(
                         node1,
                         this.astCtxt.extract(0, 0,
                           this.astCtxt.bvlshr(
                             this.astCtxt.extract(high, low, this.astCtxt.reference(parent)),
                             this.astCtxt.bv(counter, BitSizes.Byte)
                           )
                        )
                      );
            }

            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(this.astCtxt.zx(bvSize - op2.BitvectorSize, op2), this.astCtxt.bv(0, bvSize)),
                           this.astBuilder.GetOperandAst(pf),
                           node1
                         );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, pf.Register, "Parity flag");

        }


        void sf_s(Instruction inst,
                                AbstractNode parent,
                                OperandWrapper dst,
                                bool vol = false)
        {

            var bvSize = dst.BitSize;
            var high = vol ? bvSize - 1 : dst.High;

            /*
             * Create the semantic.
             * sf = high:bool(regDst)
             */
            var node = this.astCtxt.extract(high, high, this.astCtxt.reference(parent));

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_SF), "Sign flag");

        }


        void sfShl_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op2,
                                   bool vol = false)
        {
            return;
            var bvSize = dst.BitSize;
            var high = vol ? bvSize - 1 : dst.High;
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));

            /*
             * Create the semantic.
             * sf if op2 != 0
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize)),
                          this.astBuilder.GetOperandAst(sf),
                          this.astCtxt.extract(high, high, this.astCtxt.reference(parent))
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, sf.Register, "Sign flag");

        }


        void sfShld_s(Instruction inst,
                                    AbstractNode parent,
                                    OperandWrapper dst,
                                    AbstractNode op1,
                                    AbstractNode op2,
                                    AbstractNode op3,
                                    bool vol = false)
        {

            var bvSize = dst.BitSize;
            var bv1Size = op1.BitvectorSize;
            var bv2Size = op2.BitvectorSize;
            var bv3Size = op3.BitvectorSize;
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));

            /*
             * Create the semantic.
             * MSB(rol(op3, concat(op2,op1))) if op3 != 0
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op3, this.astCtxt.bv(0, bv3Size)),
                          this.astBuilder.GetOperandAst(sf),
                          this.astCtxt.extract(
                            bvSize - 1, bvSize - 1,
                            this.astCtxt.bvrol(
                              this.astCtxt.concat(op2, op1),
                              this.astCtxt.zx(((bv1Size + bv2Size) - bv3Size), op3)
                            )
                          )
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, sf.Register, "Sign flag");

        }


        void sfShrd_s(Instruction inst,
                                    AbstractNode parent,
                                    OperandWrapper dst,
                                    AbstractNode op1,
                                    AbstractNode op2,
                                    AbstractNode op3,
                                    bool vol = false)
        {

            var bvSize = dst.BitSize;
            var bv1Size = op1.BitvectorSize;
            var bv2Size = op2.BitvectorSize;
            var bv3Size = op3.BitvectorSize;
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));

            /*
             * Create the semantic.
             * MSB(ror(op3, concat(op2,op1))) if op3 != 0
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op3, this.astCtxt.bv(0, bv3Size)),
                          this.astBuilder.GetOperandAst(sf),
                          this.astCtxt.extract(
                            bvSize - 1, bvSize - 1,
                            this.astCtxt.bvror(
                              this.astCtxt.concat(op2, op1),
                              this.astCtxt.zx(((bv1Size + bv2Size) - bv3Size), op3)
                            )
                          )
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, sf.Register, "Sign flag");

        }


        void zf_s(Instruction inst,
                                AbstractNode parent,
                                OperandWrapper dst,
                                bool vol = false)
        {
            return;
            var bvSize = dst.BitSize;
            var low = vol ? 0 : dst.Low;
            var high = vol ? bvSize - 1 : dst.High;

            /*
             * Create the semantic.
             * zf = 0 == regDst
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            this.astCtxt.extract(high, low, this.astCtxt.reference(parent)),
                            this.astCtxt.bv(0, bvSize)
                          ),
                          this.astCtxt.bv(1, 1),
                          this.astCtxt.bv(0, 1)
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_ZF), "Zero flag");

        }


        void zfBsf_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper src,
                                   AbstractNode op2,
                                   bool vol = false)
        {

            /*
             * Create the semantic.
             * zf = 1 if op2 == 0 else 0
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bv(0, src.BitSize)),
                          this.astCtxt.bvtrue(),
                          this.astCtxt.bvfalse()
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_ZF), "Zero flag");

        }


        void zfShl_s(Instruction inst,
                                   AbstractNode parent,
                                   OperandWrapper dst,
                                   AbstractNode op2,
                                   bool vol = false)
        {
            return;
            var bvSize = dst.BitSize;
            var low = vol ? 0 : dst.Low;
            var high = vol ? bvSize - 1 : dst.High;
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /*
             * Create the semantic.
             * zf if op2 != 0
             */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(this.astCtxt.zx(bvSize - op2.BitvectorSize, op2), this.astCtxt.bv(0, bvSize)),
                          this.astBuilder.GetOperandAst(zf),
                          this.astCtxt.ite(
                            this.astCtxt.equal(
                              this.astCtxt.extract(high, low, this.astCtxt.reference(parent)),
                              this.astCtxt.bv(0, bvSize)
                            ),
                            this.astCtxt.bv(1, 1),
                            this.astCtxt.bv(0, 1)
                          )
                        );

            /* Create the symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, zf.Register, "Zero flag");

        }


        void aaa_s(Instruction inst)
        {
            var src1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AL));
            var src2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AH));
            var src3 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));
            var dsttmp = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AL));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);
            var op3 = this.astBuilder.GetOperandAst(inst, src3);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          // if
                          this.astCtxt.lor(
                            this.astCtxt.bvugt(
                              this.astCtxt.bvand(op1, this.astCtxt.bv(0xf, src1.BitSize)),
                              this.astCtxt.bv(9, src1.BitSize)
                            ),
                            this.astCtxt.equal(op3, this.astCtxt.bvtrue())
                          ),
                          // then
                          this.astCtxt.concat(
                            this.astCtxt.bvadd(op2, this.astCtxt.bv(1, src2.BitSize)),
                            this.astCtxt.bvand(
                              this.astCtxt.bvadd(op1, this.astCtxt.bv(6, src1.BitSize)),
                              this.astCtxt.bv(0xf, src1.BitSize)
                            )
                          ),
                          // else
                          this.astCtxt.concat(
                            op2,
                            this.astCtxt.bvand(op1, this.astCtxt.bv(0xf, src1.BitSize))
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "AAA operation");


            /* Update symbolic flags */
            this.afAaa_s(inst, expr, dsttmp, op1, op3);
            this.cfAaa_s(inst, expr, dsttmp, op1, op3);

            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void aad_s(Instruction inst)
        {
            var src1 = new OperandWrapper(new Immediate(0x0a, ByteSizes.Byte)); /* D5 0A */
            var src2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AL));
            var src3 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AH));
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));
            var dsttmp = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AL));

            /* D5 ib */
            if (inst.Operands.Count() == 1)
                src1 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);
            var op3 = this.astBuilder.GetOperandAst(inst, src3);

            /* Create the semantics */
            var node = this.astCtxt.zx(
                          BitSizes.Byte,
                          this.astCtxt.bvadd(
                            op2,
                            this.astCtxt.bvmul(op3, op1)
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "AAD operation");


            /* Update symbolic flags */
            this.pf_s(inst, expr, dsttmp);
            this.sf_s(inst, expr, dsttmp);
            this.zf_s(inst, expr, dsttmp);

            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void aam_s(Instruction inst)
        {
            var src1 = new OperandWrapper(new Immediate(0x0a, ByteSizes.Byte)); /* D4 0A */
            var src2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AL));
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));
            var dsttmp = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AL));

            /* D4 ib */
            if (inst.Operands.Count() == 1)
                src1 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            var node = this.astCtxt.concat(
                          this.astCtxt.bvudiv(op2, op1),
                          this.astCtxt.bvurem(op2, op1)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "AAM operation");


            /* Update symbolic flags */
            this.pf_s(inst, expr, dsttmp);
            this.sf_s(inst, expr, dsttmp);
            this.zf_s(inst, expr, dsttmp);

            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void aas_s(Instruction inst)
        {
            var src1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AL));
            var src2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AH));
            var src3 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));
            var dsttmp = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AL));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);
            var op3 = this.astBuilder.GetOperandAst(inst, src3);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          // if
                          this.astCtxt.lor(
                            this.astCtxt.bvugt(
                              this.astCtxt.bvand(op1, this.astCtxt.bv(0xf, src1.BitSize)),
                              this.astCtxt.bv(9, src1.BitSize)
                            ),
                            this.astCtxt.equal(op3, this.astCtxt.bvtrue())
                          ),
                          // then
                          this.astCtxt.concat(
                            this.astCtxt.bvsub(op2, this.astCtxt.bv(1, src2.BitSize)),
                            this.astCtxt.bvand(
                              this.astCtxt.bvsub(op1, this.astCtxt.bv(6, src1.BitSize)),
                              this.astCtxt.bv(0xf, src1.BitSize)
                            )
                          ),
                          // else
                          this.astCtxt.concat(
                            op2,
                            this.astCtxt.bvand(op1, this.astCtxt.bv(0xf, src1.BitSize))
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "AAS operation");


            /* Update symbolic flags */
            this.afAaa_s(inst, expr, dsttmp, op1, op3);
            this.cfAaa_s(inst, expr, dsttmp, op1, op3);

            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void adc_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, cf);

            /* Create the semantics */
            var node = this.astCtxt.bvadd(this.astCtxt.bvadd(op1, op2), this.astCtxt.zx(dst.BitSize - 1, op3));

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "ADC operation");


            /* Update symbolic flags */
            this.af_s(inst, expr, dst, op1, op2);
            this.cfAdd_s(inst, expr, dst, op1, op2);
            this.ofAdd_s(inst, expr, dst, op1, op2);
            this.pf_s(inst, expr, dst);
            this.sf_s(inst, expr, dst);
            this.zf_s(inst, expr, dst);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void adcx_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, cf);

            /* Create the semantics */
            var node = this.astCtxt.bvadd(this.astCtxt.bvadd(op1, op2), this.astCtxt.zx(dst.BitSize - 1, op3));

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "ADCX operation");


            /* Update symbolic flags */
            this.cfAdd_s(inst, expr, dst, op1, op2);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void add_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvadd(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "ADD operation");


            /* Update symbolic flags */
            this.af_s(inst, expr, dst, op1, op2);
            this.cfAdd_s(inst, expr, dst, op1, op2);
            this.ofAdd_s(inst, expr, dst, op1, op2);
            this.pf_s(inst, expr, dst);
            this.sf_s(inst, expr, dst);
            this.zf_s(inst, expr, dst);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void and_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvand(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "AND operation");


            /* Update symbolic flags */
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Clears carry flag");
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Clears overflow flag");
            this.pf_s(inst, expr, dst);
            this.sf_s(inst, expr, dst);
            this.zf_s(inst, expr, dst);

            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void andn_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            var node = this.astCtxt.bvand(this.astCtxt.bvnot(op2), op3);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "ANDN operation");


            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Clears carry flag");
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Clears overflow flag");
            this.sf_s(inst, expr, dst);
            this.zf_s(inst, expr, dst);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void andnpd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvand(this.astCtxt.bvnot(op1), op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "ANDNPD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void andnps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvand(this.astCtxt.bvnot(op1), op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "ANDNPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void andpd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvand(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "ANDPD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void andps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvand(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "ANDPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void bextr_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            var node = this.astCtxt.bvand(
                          this.astCtxt.bvlshr(
                            op1,
                            this.astCtxt.zx(src1.BitSize - BitSizes.Byte, this.astCtxt.extract(7, 0, op2))
                          ),
                          this.astCtxt.bvsub(
                            this.astCtxt.bvshl(
                              this.astCtxt.bv(1, src1.BitSize),
                              this.astCtxt.zx(src1.BitSize - BitSizes.Byte, this.astCtxt.extract(15, 8, op2))
                            ),
                            this.astCtxt.bv(1, src1.BitSize)
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "BEXTR operation");


            /* Update symbolic flags */
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Clears carry flag");
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Clears overflow flag");
            this.zf_s(inst, expr, dst);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void blsi_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvand(this.astCtxt.bvneg(op1), op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "BLSI operation");


            /* Update symbolic flags */
            this.cfBlsi_s(inst, expr, src, op1);
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Clears overflow flag");
            this.sf_s(inst, expr, dst);
            this.zf_s(inst, expr, dst);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void blsmsk_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvxor(
                          this.astCtxt.bvsub(op1, this.astCtxt.bv(1, src.BitSize)),
                          op1
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "BLSMSK operation");


            /* Update symbolic flags */
            this.cfBlsmsk_s(inst, expr, src, op1);
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Clears overflow flag");
            this.sf_s(inst, expr, dst);
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_ZF), "Clears zero flag");

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void blsr_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvand(
                          this.astCtxt.bvsub(op1, this.astCtxt.bv(1, src.BitSize)),
                          op1
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "BLSR operation");


            /* Update symbolic flags */
            this.cfBlsr_s(inst, expr, src, op1);
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Clears overflow flag");
            this.sf_s(inst, expr, dst);
            this.zf_s(inst, expr, dst);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void bsf_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var bvSize1 = dst.BitSize;
            var bvSize2 = src.BitSize;

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            AbstractNode node = null;
            switch (src.Size)
            {
                case ByteSizes.Byte:
                    node = this.astCtxt.ite(
                             this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize2)), /* Apply BSF only if op2 != 0 */
                             op1,
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(0, 0, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(1, 1, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(2, 2, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(3, 3, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(4, 4, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(5, 5, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(6, 6, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(7, 7, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                             this.astCtxt.bv(0, bvSize1)
                             ))))))))
                           );
                    break;
                case ByteSizes.Word:
                    node = this.astCtxt.ite(
                             this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize2)), /* Apply BSF only if op2 != 0 */
                             op1,
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(0, 0, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(1, 1, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(2, 2, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(3, 3, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(4, 4, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(5, 5, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(6, 6, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(7, 7, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(8, 8, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(8, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(9, 9, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(9, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(10, 10, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(10, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(11, 11, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(11, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(12, 12, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(12, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(13, 13, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(13, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(14, 14, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(14, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(15, 15, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(15, bvSize1),
                             this.astCtxt.bv(0, bvSize1)
                             ))))))))))))))))
                           );
                    break;
                case ByteSizes.Dword:
                    node = this.astCtxt.ite(
                             this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize2)), /* Apply BSF only if op2 != 0 */
                             op1,
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(0, 0, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(1, 1, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(2, 2, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(3, 3, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(4, 4, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(5, 5, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(6, 6, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(7, 7, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(8, 8, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(8, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(9, 9, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(9, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(10, 10, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(10, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(11, 11, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(11, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(12, 12, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(12, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(13, 13, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(13, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(14, 14, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(14, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(15, 15, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(15, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(16, 16, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(16, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(17, 17, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(17, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(18, 18, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(18, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(19, 19, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(19, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(20, 20, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(20, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(21, 21, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(21, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(22, 22, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(22, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(23, 23, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(23, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(24, 24, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(24, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(25, 25, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(25, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(26, 26, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(26, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(27, 27, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(27, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(28, 28, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(28, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(29, 29, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(29, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(30, 30, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(30, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(31, 31, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(31, bvSize1),
                             this.astCtxt.bv(0, bvSize1)
                             ))))))))))))))))))))))))))))))))
                           );
                    break;
                case ByteSizes.Qword:
                    node = this.astCtxt.ite(
                             this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize2)), /* Apply BSF only if op2 != 0 */
                             op1,
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(0, 0, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(1, 1, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(2, 2, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(3, 3, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(4, 4, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(5, 5, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(6, 6, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(7, 7, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(8, 8, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(8, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(9, 9, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(9, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(10, 10, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(10, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(11, 11, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(11, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(12, 12, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(12, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(13, 13, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(13, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(14, 14, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(14, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(15, 15, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(15, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(16, 16, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(16, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(17, 17, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(17, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(18, 18, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(18, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(19, 19, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(19, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(20, 20, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(20, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(21, 21, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(21, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(22, 22, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(22, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(23, 23, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(23, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(24, 24, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(24, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(25, 25, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(25, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(26, 26, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(26, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(27, 27, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(27, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(28, 28, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(28, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(29, 29, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(29, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(30, 30, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(30, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(31, 31, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(31, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(32, 32, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(32, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(33, 33, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(33, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(34, 34, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(34, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(35, 35, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(35, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(36, 36, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(36, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(37, 37, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(37, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(38, 38, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(38, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(39, 39, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(39, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(40, 40, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(40, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(41, 41, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(41, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(42, 42, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(42, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(43, 43, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(43, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(44, 44, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(44, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(45, 45, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(45, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(46, 46, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(46, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(47, 47, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(47, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(48, 48, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(48, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(49, 49, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(49, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(50, 50, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(50, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(51, 51, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(51, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(52, 52, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(52, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(53, 53, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(53, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(54, 54, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(54, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(55, 55, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(55, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(56, 56, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(56, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(57, 57, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(57, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(58, 58, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(58, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(59, 59, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(59, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(60, 60, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(60, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(61, 61, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(61, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(62, 62, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(62, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(63, 63, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(63, bvSize1),
                             this.astCtxt.bv(0, bvSize1)
                             ))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))
                           );
                    break;
                default:
                    throw new Exception("bsf_s(): Invalid operand size.");
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "BSF operation");


            /* Update symbolic flags */
            this.zfBsf_s(inst, expr, src, op2);

            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void bsr_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var bvSize1 = dst.BitSize;
            var bvSize2 = src.BitSize;

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            AbstractNode node = null;
            switch (src.Size)
            {
                case ByteSizes.Byte:
                    node = this.astCtxt.ite(
                             this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize2)), /* Apply BSR only if op2 != 0 */
                             op1,
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(7, 7, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(6, 6, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(5, 5, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(4, 4, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(3, 3, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(2, 2, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(1, 1, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(0, 0, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                             this.astCtxt.bv(0, bvSize1)
                             ))))))))
                           );
                    break;
                case ByteSizes.Word:
                    node = this.astCtxt.ite(
                             this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize2)), /* Apply BSR only if op2 != 0 */
                             op1,
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(15, 15, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(15, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(14, 14, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(14, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(13, 13, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(13, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(12, 12, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(12, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(11, 11, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(11, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(10, 10, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(10, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(9, 9, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(9, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(8, 8, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(8, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(7, 7, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(6, 6, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(5, 5, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(4, 4, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(3, 3, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(2, 2, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(1, 1, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(0, 0, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                             this.astCtxt.bv(0, bvSize1)
                             ))))))))))))))))
                           );
                    break;
                case ByteSizes.Dword:
                    node = this.astCtxt.ite(
                             this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize2)), /* Apply BSR only if op2 != 0 */
                             op1,
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(31, 31, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(31, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(30, 30, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(30, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(29, 29, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(29, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(28, 28, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(28, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(27, 27, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(27, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(26, 26, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(26, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(25, 25, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(25, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(24, 24, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(24, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(23, 23, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(23, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(22, 22, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(22, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(21, 21, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(21, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(20, 20, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(20, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(19, 19, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(19, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(18, 18, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(18, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(17, 17, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(17, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(16, 16, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(16, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(15, 15, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(15, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(14, 14, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(14, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(13, 13, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(13, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(12, 12, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(12, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(11, 11, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(11, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(10, 10, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(10, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(9, 9, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(9, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(8, 8, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(8, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(7, 7, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(6, 6, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(5, 5, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(4, 4, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(3, 3, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(2, 2, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(1, 1, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(0, 0, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                             this.astCtxt.bv(0, bvSize1)
                             ))))))))))))))))))))))))))))))))
                           );
                    break;
                case ByteSizes.Qword:
                    node = this.astCtxt.ite(
                             this.astCtxt.equal(op2, this.astCtxt.bv(0, bvSize2)), /* Apply BSR only if op2 != 0 */
                             op1,
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(63, 63, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(63, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(62, 62, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(62, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(61, 61, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(61, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(60, 60, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(60, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(59, 59, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(59, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(58, 58, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(58, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(57, 57, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(57, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(56, 56, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(56, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(55, 55, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(55, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(54, 54, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(54, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(53, 53, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(53, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(52, 52, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(52, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(51, 51, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(51, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(50, 50, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(50, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(49, 49, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(49, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(48, 48, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(48, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(47, 47, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(47, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(46, 46, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(46, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(45, 45, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(45, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(44, 44, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(44, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(43, 43, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(43, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(42, 42, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(42, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(41, 41, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(41, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(40, 40, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(40, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(39, 39, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(39, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(38, 38, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(38, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(37, 37, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(37, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(36, 36, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(36, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(35, 35, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(35, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(34, 34, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(34, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(33, 33, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(33, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(32, 32, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(32, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(31, 31, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(31, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(30, 30, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(30, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(29, 29, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(29, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(28, 28, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(28, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(27, 27, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(27, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(26, 26, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(26, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(25, 25, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(25, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(24, 24, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(24, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(23, 23, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(23, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(22, 22, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(22, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(21, 21, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(21, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(20, 20, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(20, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(19, 19, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(19, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(18, 18, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(18, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(17, 17, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(17, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(16, 16, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(16, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(15, 15, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(15, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(14, 14, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(14, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(13, 13, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(13, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(12, 12, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(12, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(11, 11, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(11, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(10, 10, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(10, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(9, 9, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(9, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(8, 8, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(8, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(7, 7, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(6, 6, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(5, 5, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(4, 4, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(3, 3, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(2, 2, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(1, 1, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(0, 0, op2), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                             this.astCtxt.bv(0, bvSize1)
                             ))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))
                           );
                    break;
                default:
                    throw new Exception("bsr_s(): Invalid operand size.");
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "BSR operation");


            /* Update symbolic flags */
            this.zfBsf_s(inst, expr, src, op2); /* same as bsf */

            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void bswap_s(Instruction inst)
        {
            var src = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> bytes = new List<AbstractNode>();
            switch (src.Size)
            {
                case ByteSizes.Qword:
                    bytes.Insert(0, this.astCtxt.extract(63, 56, op1));
                    bytes.Insert(0, this.astCtxt.extract(55, 48, op1));
                    bytes.Insert(0, this.astCtxt.extract(47, 40, op1));
                    bytes.Insert(0, this.astCtxt.extract(39, 32, op1));
                    goto case ByteSizes.Dword;
                case ByteSizes.Dword:
                    bytes.Insert(0, this.astCtxt.extract(31, 24, op1));
                    bytes.Insert(0, this.astCtxt.extract(23, 16, op1));
                    goto case ByteSizes.Word;
                case ByteSizes.Word:
                    bytes.Insert(0, this.astCtxt.extract(15, 8, op1));
                    bytes.Insert(0, this.astCtxt.extract(7, 0, op1));
                    break;
                default:
                    throw new Exception("bswap_s(): Invalid operand size.");
            }

            var node = this.astCtxt.concat(bytes);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, src, "BSWAP operation");


            /* Tag undefined registers */
            if (src.Size == ByteSizes.Word)
            {
                // When the BSWAP instruction references a 16-bit register, the result is undefined.
                this.undefined_s(inst, src.Register);
            }

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void bt_s(Instruction inst)
        {
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var src1 = inst.Operands[0];
            var src2 = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astCtxt.zx(src1.BitSize - src2.BitSize, this.astBuilder.GetOperandAst(inst, src2));

            /* Create the semantics */
            var node = this.astCtxt.extract(0, 0,
                          this.astCtxt.bvlshr(
                            op1,
                            this.astCtxt.bvsmod(
                              op2,
                              this.astCtxt.bv(src1.BitSize, src1.BitSize)
                            )
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "BT operation");


            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void btc_s(Instruction inst)
        {
            var dst1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var dst2 = inst.Operands[0];
            var src1 = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst2);
            var op2 = this.astCtxt.zx(dst2.BitSize - src1.BitSize, this.astBuilder.GetOperandAst(inst, src1));

            /* Create the semantics */
            var node1 = this.astCtxt.extract(0, 0,
                           this.astCtxt.bvlshr(
                             op1,
                             this.astCtxt.bvsmod(
                               op2,
                               this.astCtxt.bv(dst2.BitSize, dst2.BitSize)
                             )
                           )
                         );
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(node1, this.astCtxt.bvfalse()),
                           /* BTS */
                           this.astCtxt.bvor(
                             op1,
                             this.astCtxt.bvshl(
                               this.astCtxt.bv(1, dst2.BitSize),
                               this.astCtxt.bvsmod(
                                 op2,
                                 this.astCtxt.bv(dst2.BitSize, dst2.BitSize)
                               )
                             )
                           ),
                           /* BTR */
                           this.astCtxt.bvand(
                             op1,
                             this.astCtxt.bvsub(
                               op1,
                               this.astCtxt.bvshl(
                                 this.astCtxt.bv(1, dst2.BitSize),
                                 this.astCtxt.bvsmod(
                                   op2,
                                   this.astCtxt.bv(dst2.BitSize, dst2.BitSize)
                                 )
                               )
                             )
                           )
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "BTC carry operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst2, "BTC complement operation");


            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void btr_s(Instruction inst)
        {
            var dst1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var dst2 = inst.Operands[0];
            var src1 = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst2);
            var op2 = this.astCtxt.zx(dst2.BitSize - src1.BitSize, this.astBuilder.GetOperandAst(inst, src1));

            /* Create the semantics */
            var node1 = this.astCtxt.extract(0, 0,
                           this.astCtxt.bvlshr(
                             op1,
                             this.astCtxt.bvsmod(
                               op2,
                               this.astCtxt.bv(dst2.BitSize, dst2.BitSize)
                             )
                           )
                         );
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(node1, this.astCtxt.bvfalse()),
                           op1,
                           this.astCtxt.bvand(
                             op1,
                             this.astCtxt.bvsub(
                               op1,
                               this.astCtxt.bvshl(
                                 this.astCtxt.bv(1, dst2.BitSize),
                                 this.astCtxt.bvsmod(
                                   op2,
                                   this.astCtxt.bv(dst2.BitSize, dst2.BitSize)
                                 )
                               )
                             )
                           )
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "BTR carry operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst2, "BTR reset operation");


            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void bts_s(Instruction inst)
        {
            var dst1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var dst2 = inst.Operands[0];
            var src1 = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst2);
            var op2 = this.astCtxt.zx(dst2.BitSize - src1.BitSize, this.astBuilder.GetOperandAst(inst, src1));

            /* Create the semantics */
            var node1 = this.astCtxt.extract(0, 0,
                           this.astCtxt.bvlshr(
                             op1,
                             this.astCtxt.bvsmod(
                               op2,
                               this.astCtxt.bv(dst2.BitSize, dst2.BitSize)
                             )
                           )
                         );
            var node2 = this.astCtxt.bvor(
                           op1,
                           this.astCtxt.bvshl(
                             this.astCtxt.bv(1, dst2.BitSize),
                             this.astCtxt.bvsmod(
                               op2,
                               this.astCtxt.bv(dst2.BitSize, dst2.BitSize)
                             )
                           )
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "BTS carry operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst2, "BTS set operation");


            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void call_s(Instruction inst)
        {
            var stack = this.architecture.GetStackPointer();

            /* Create the semantics - side effect */
            var stackValue = alignSubStack_s(inst, stack.Size);
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var sp = new MemoryNode(stackValue, stack.BitSize);
            var src = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics - side effect */
            var node1 = this.astCtxt.bv(inst.NextAddress, pc.BitSize);

            /* Create the semantics */
            var node2 = op1;

            /* Create the symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, sp, "Saved Program Counter");

            /* Create symbolic expression */
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, pc, "Program Counter");


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr2);
        }


        void cbw_s(Instruction inst)
        {
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);

            /* Create the semantics */
            var node = this.astCtxt.sx(BitSizes.Byte, this.astCtxt.extract(BitSizes.Byte - 1, 0, op1));

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CBW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cdq_s(Instruction inst)
        {
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EDX));
            var src = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EAX));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics - TMP = 64 bitvec (EDX:EAX) */
            var node1 = this.astCtxt.sx(BitSizes.Dword, op1);

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "Temporary variable");


            /* Create the semantics - EDX = TMP[63...32] */
            var node2 = this.astCtxt.extract(BitSizes.Qword - 1, BitSizes.Dword, this.astCtxt.reference(expr1));

            /* Create symbolic expression */
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst, "CDQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cdqe_s(Instruction inst)
        {
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RAX));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);

            /* Create the semantics */
            var node = this.astCtxt.sx(BitSizes.Dword, this.astCtxt.extract(BitSizes.Dword - 1, 0, op1));

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CDQE operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void clc_s(Instruction inst)
        {
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Clears carry flag");
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cld_s(Instruction inst)
        {
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_DF), "Clears direction flag");
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void clflush_s(Instruction inst)
        {
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void clts_s(Instruction inst)
        {
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CR0));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);

            /* Create the semantics */
            AbstractNode node = null;

            switch (dst.BitSize)
            {
                case BitSizes.Qword:
                    node = this.astCtxt.bvand(op1, this.astCtxt.bv(0xfffffffffffffff7, BitSizes.Qword));
                    break;
                case BitSizes.Dword:
                    node = this.astCtxt.bvand(op1, this.astCtxt.bv(0xfffffff7, BitSizes.Dword));
                    break;
                default:
                    throw new Exception("clts_s(): Invalid operand size.");
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CLTS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cli_s(Instruction inst)
        {
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_IF), "Clears interrupt flag");
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmc_s(Instruction inst)
        {
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);

            /* Create the semantics */
            var node = this.astCtxt.bvnot(op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst.Register, "CMC operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmova_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, cf);
            var op4 = this.astBuilder.GetOperandAst(inst, zf);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.bvand(this.astCtxt.bvnot(op3), this.astCtxt.bvnot(op4)), this.astCtxt.bvtrue()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVA operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmovae_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, cf);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op3, this.astCtxt.bvfalse()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVAE operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmovb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, cf);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op3, this.astCtxt.bvtrue()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVB operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmovbe_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, cf);
            var op4 = this.astBuilder.GetOperandAst(inst, zf);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.bvor(op3, op4), this.astCtxt.bvtrue()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVBE operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmove_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, zf);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op3, this.astCtxt.bvtrue()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVE operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmovg_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, sf);
            var op4 = this.astBuilder.GetOperandAst(inst, of);
            var op5 = this.astBuilder.GetOperandAst(inst, zf);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.bvor(this.astCtxt.bvxor(op3, op4), op5), this.astCtxt.bvfalse()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVG operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmovge_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, sf);
            var op4 = this.astBuilder.GetOperandAst(inst, of);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op3, op4), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVGE operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmovl_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, sf);
            var op4 = this.astBuilder.GetOperandAst(inst, of);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.bvxor(op3, op4), this.astCtxt.bvtrue()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVL operation");




            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmovle_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, sf);
            var op4 = this.astBuilder.GetOperandAst(inst, of);
            var op5 = this.astBuilder.GetOperandAst(inst, zf);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.bvor(this.astCtxt.bvxor(op3, op4), op5), this.astCtxt.bvtrue()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVBE operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmovne_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, zf);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op3, this.astCtxt.bvfalse()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVNE operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmovno_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, of);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op3, this.astCtxt.bvfalse()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVNO operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmovnp_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var pf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_PF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, pf);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op3, this.astCtxt.bvfalse()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVNP operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmovns_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, sf);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op3, this.astCtxt.bvfalse()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVNS operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmovo_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, of);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op3, this.astCtxt.bvtrue()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVO operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmovp_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var pf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_PF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, pf);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op3, this.astCtxt.bvtrue()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVP operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmovs_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, sf);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op3, this.astCtxt.bvtrue()), op2, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CMOVS operation");



            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmp_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astCtxt.sx(dst.BitSize - src.BitSize, this.astBuilder.GetOperandAst(inst, src));

            /* Create the semantics */
            var node = this.astCtxt.bvsub(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicExpression(inst, node, "CMP operation");


            /* Update symbolic flags */
            this.af_s(inst, expr, dst, op1, op2, true);
            this.cfSub_s(inst, expr, dst, op1, op2, true);
            this.ofSub_s(inst, expr, dst, op1, op2, true);
            this.pf_s(inst, expr, dst, true);
            this.sf_s(inst, expr, dst, true);
            this.zf_s(inst, expr, dst, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmpsb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index1 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_SI));
            var index2 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* If the REP prefix is defined, convert REP into REPE */
            if (inst.Prefix == Prefix.ID_PREFIX_REP)
                inst.Prefix = Prefix.ID_PREFIX_REP;

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, index1);
            var op4 = this.astBuilder.GetOperandAst(inst, index2);
            var op5 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = this.astCtxt.bvsub(op1, op2);
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op5, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op3, this.astCtxt.bv(ByteSizes.Byte, index1.BitSize)),
                           this.astCtxt.bvsub(op3, this.astCtxt.bv(ByteSizes.Byte, index1.BitSize))
                         );
            var node3 = this.astCtxt.ite(
                           this.astCtxt.equal(op5, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op4, this.astCtxt.bv(ByteSizes.Byte, index2.BitSize)),
                           this.astCtxt.bvsub(op4, this.astCtxt.bv(ByteSizes.Byte, index2.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "CMPSB operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index1, "Index (SI) operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, index2, "Index (DI) operation");


            /* Update symbolic flags */
            this.af_s(inst, expr1, dst, op1, op2, true);
            this.cfSub_s(inst, expr1, dst, op1, op2, true);
            this.ofSub_s(inst, expr1, dst, op1, op2, true);
            this.pf_s(inst, expr1, dst, true);
            this.sf_s(inst, expr1, dst, true);
            this.zf_s(inst, expr1, dst, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmpsd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index1 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_SI));
            var index2 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* If the REP prefix is defined, convert REP into REPE */
            if (inst.Prefix == Prefix.ID_PREFIX_REP)
                inst.Prefix = Prefix.ID_PREFIX_REP;

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, index1);
            var op4 = this.astBuilder.GetOperandAst(inst, index2);
            var op5 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = this.astCtxt.bvsub(op1, op2);
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op5, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op3, this.astCtxt.bv(ByteSizes.Dword, index1.BitSize)),
                           this.astCtxt.bvsub(op3, this.astCtxt.bv(ByteSizes.Dword, index1.BitSize))
                         );
            var node3 = this.astCtxt.ite(
                           this.astCtxt.equal(op5, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op4, this.astCtxt.bv(ByteSizes.Dword, index2.BitSize)),
                           this.astCtxt.bvsub(op4, this.astCtxt.bv(ByteSizes.Dword, index2.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "CMPSD operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index1, "Index (SI) operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, index2, "Index (DI) operation");


            /* Update symbolic flags */
            this.af_s(inst, expr1, dst, op1, op2, true);
            this.cfSub_s(inst, expr1, dst, op1, op2, true);
            this.ofSub_s(inst, expr1, dst, op1, op2, true);
            this.pf_s(inst, expr1, dst, true);
            this.sf_s(inst, expr1, dst, true);
            this.zf_s(inst, expr1, dst, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmpsq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index1 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_SI));
            var index2 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* If the REP prefix is defined, convert REP into REPE */
            if (inst.Prefix == Prefix.ID_PREFIX_REP)
                inst.Prefix = Prefix.ID_PREFIX_REP;

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, index1);
            var op4 = this.astBuilder.GetOperandAst(inst, index2);
            var op5 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = this.astCtxt.bvsub(op1, op2);
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op5, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op3, this.astCtxt.bv(ByteSizes.Qword, index1.BitSize)),
                           this.astCtxt.bvsub(op3, this.astCtxt.bv(ByteSizes.Qword, index1.BitSize))
                         );
            var node3 = this.astCtxt.ite(
                           this.astCtxt.equal(op5, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op4, this.astCtxt.bv(ByteSizes.Qword, index2.BitSize)),
                           this.astCtxt.bvsub(op4, this.astCtxt.bv(ByteSizes.Qword, index2.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "CMPSQ operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index1, "Index (SI) operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, index2, "Index (DI) operation");


            /* Update symbolic flags */
            this.af_s(inst, expr1, dst, op1, op2, true);
            this.cfSub_s(inst, expr1, dst, op1, op2, true);
            this.ofSub_s(inst, expr1, dst, op1, op2, true);
            this.pf_s(inst, expr1, dst, true);
            this.sf_s(inst, expr1, dst, true);
            this.zf_s(inst, expr1, dst, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmpsw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index1 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_SI));
            var index2 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* If the REP prefix is defined, convert REP into REPE */
            if (inst.Prefix == Prefix.ID_PREFIX_REP)
                inst.Prefix = Prefix.ID_PREFIX_REP;

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, index1);
            var op4 = this.astBuilder.GetOperandAst(inst, index2);
            var op5 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = this.astCtxt.bvsub(op1, op2);
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op5, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op3, this.astCtxt.bv(ByteSizes.Word, index1.BitSize)),
                           this.astCtxt.bvsub(op3, this.astCtxt.bv(ByteSizes.Word, index1.BitSize))
                         );
            var node3 = this.astCtxt.ite(
                           this.astCtxt.equal(op5, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op4, this.astCtxt.bv(ByteSizes.Word, index2.BitSize)),
                           this.astCtxt.bvsub(op4, this.astCtxt.bv(ByteSizes.Word, index2.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "CMPSW operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index1, "Index (SI) operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, index2, "Index (DI) operation");


            /* Update symbolic flags */
            this.af_s(inst, expr1, dst, op1, op2, true);
            this.cfSub_s(inst, expr1, dst, op1, op2, true);
            this.ofSub_s(inst, expr1, dst, op1, op2, true);
            this.pf_s(inst, expr1, dst, true);
            this.sf_s(inst, expr1, dst, true);
            this.zf_s(inst, expr1, dst, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmpxchg_s(Instruction inst)
        {
            var src1 = inst.Operands[0];
            var src2 = inst.Operands[1];

            /* Create the tempory accumulator */
            OperandWrapper accumulator = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AL));
            OperandWrapper accumulatorp = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_AL));

            switch (src1.Size)
            {
                case ByteSizes.Word:
                    accumulator.Register = (new Register(this.architecture.GetRegister(register_e.ID_REG_X86_AX)));
                    break;
                case ByteSizes.Dword:
                    accumulator.Register = (new Register(this.architecture.GetRegister(register_e.ID_REG_X86_EAX)));
                    break;
                case ByteSizes.Qword:
                    accumulator.Register = (new Register(this.architecture.GetRegister(register_e.ID_REG_X86_RAX)));
                    break;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, accumulator);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);
            var op1p = this.astBuilder.GetOperandAst(accumulatorp);
            var op2p = this.astBuilder.GetRegisterAst((src1.Type == OperandType.Reg ? new Register(this.architecture.GetParentRegister(src1.Register)) : accumulatorp.Register));
            var op3p = this.astBuilder.GetRegisterAst((src1.Type == OperandType.Reg ? new Register(this.architecture.GetParentRegister(src2.Register)) : accumulatorp.Register));

            /* Create the semantics */
            var nodeq = this.astCtxt.equal(op1, op2);
            var node1 = this.astCtxt.bvsub(op1, op2);
            var node2 = this.astCtxt.ite(nodeq, op3, op2);
            var node3 = this.astCtxt.ite(nodeq, op1, op2);
            var node2p = this.astCtxt.ite(nodeq, op3p, op2p);
            var node3p = this.astCtxt.ite(nodeq, op1p, op2p);

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "CMP operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node2, "Temporary operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node2p, "Temporary operation");
            var expr4 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node3, "Temporary operation");
            var expr5 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node3p, "Temporary operation");

            AbstractNode expr6 = null;
            AbstractNode expr7 = null;

            /* Destination */
            if (nodeq.Evaluate() == false && src1.Type == OperandType.Reg)
            {
                var src1p = this.architecture.GetParentRegister(src1.Register);
                expr6 = this.ExpressionDatabase.StoreSymbolicRegisterAssignment(inst, node2p, src1p, "XCHG operation");
            }
            else
                expr6 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, src1, "XCHG operation");

            /* Accumulator */
            if (nodeq.Evaluate() == true)
                expr7 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3p, accumulatorp, "XCHG operation");
            else
                expr7 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, accumulator, "XCHG operation");


            /* Update symbolic flags */
            this.af_s(inst, expr1, accumulator, op1, op2, true);
            this.cfSub_s(inst, expr1, accumulator, op1, op2, true);
            this.ofSub_s(inst, expr1, accumulator, op1, op2, true);
            this.pf_s(inst, expr1, accumulator, true);
            this.sf_s(inst, expr1, accumulator, true);
            this.zf_s(inst, expr1, accumulator, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmpxchg16b_s(Instruction inst)
        {
            var src1 = inst.Operands[0];
            var src2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RDX));
            var src3 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RAX));
            var src4 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RCX));
            var src5 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RBX));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);
            var op3 = this.astBuilder.GetOperandAst(inst, src3);
            var op4 = this.astBuilder.GetOperandAst(inst, src4);
            var op5 = this.astBuilder.GetOperandAst(inst, src5);

            /* Create the semantics */
            /* CMP8B */
            var node1 = this.astCtxt.bvsub(this.astCtxt.concat(op2, op3), op1);
            /* Destination */
            var node2 = this.astCtxt.ite(this.astCtxt.equal(node1, this.astCtxt.bv(0, BitSizes.Dqword)), this.astCtxt.concat(op4, op5), op1);
            /* EDX:EAX */
            var node3 = this.astCtxt.ite(this.astCtxt.equal(node1, this.astCtxt.bv(0, BitSizes.Dqword)), this.astCtxt.concat(op2, op3), op1);

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "CMP operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, src1, "XCHG16B memory operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, this.astCtxt.extract(127, 64, node3), src2, "XCHG16B RDX operation");
            var expr4 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, this.astCtxt.extract(63, 0, node3), src3, "XCHG16B RAX operation");


            /* Update symbolic flags */
            this.zf_s(inst, expr1, src1, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cmpxchg8b_s(Instruction inst)
        {
            var src1 = inst.Operands[0];
            var src2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EDX));
            var src3 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EAX));
            var src4 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ECX));
            var src5 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EBX));
            var src2p = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_EDX));
            var src3p = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_EAX));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);
            var op3 = this.astBuilder.GetOperandAst(inst, src3);
            var op4 = this.astBuilder.GetOperandAst(inst, src4);
            var op5 = this.astBuilder.GetOperandAst(inst, src5);
            var op2p = this.astBuilder.GetOperandAst(inst, src2p);
            var op3p = this.astBuilder.GetOperandAst(inst, src3p);

            /* Create the semantics */
            /* CMP8B */
            var node1 = this.astCtxt.bvsub(this.astCtxt.concat(op2, op3), op1);
            /* Destination */
            var node2 = this.astCtxt.ite(this.astCtxt.equal(node1, this.astCtxt.bv(0, BitSizes.Qword)), this.astCtxt.concat(op4, op5), op1);
            /* EDX:EAX */
            var node3 = this.astCtxt.ite(this.astCtxt.equal(node1, this.astCtxt.bv(0, BitSizes.Qword)), this.astCtxt.concat(op2, op3), op1);
            var node3p = this.astCtxt.ite(
                            this.astCtxt.equal(
                              node1,
                              this.astCtxt.bv(0, BitSizes.Qword)),
                              this.astCtxt.concat(op2p, op3p),
                              this.astCtxt.zx(src2p.BitSize + src3p.BitSize - src1.BitSize, op1)
                          );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "CMP operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, src1, "XCHG8B memory operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node3, "Temporary operation");
            var expr4 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node3p, "Temporary operation");

            AbstractNode expr5 = null;
            AbstractNode expr6 = null;

            /* EDX */
            if (node1.Evaluate() == 0)
                expr5 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, this.astCtxt.extract((src2p.BitSize * 2 - 1), src2p.BitSize, node3p), src2p, "XCHG8B EDX operation");
            else
                expr5 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, this.astCtxt.extract(63, 32, node3), src2, "XCHG8B EDX operation");

            /* EAX */
            if (node1.Evaluate() == 0)
                expr6 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, this.astCtxt.extract(src2p.BitSize - 1, 0, node3p), src3p, "XCHG8B EAX operation");
            else
                expr6 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, this.astCtxt.extract(31, 0, node3), src3, "XCHG8B EAX operation");


            /* Update symbolic flags */
            this.zf_s(inst, expr1, src1, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cpuid_s(Instruction inst)
        {
            var src = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_AX));
            var dst1 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_AX));
            var dst2 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_BX));
            var dst3 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var dst4 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DX));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            AbstractNode node1 = null;
            AbstractNode node2 = null;
            AbstractNode node3 = null;
            AbstractNode node4 = null;

            /* In this case, we concretize the AX option */
            switch ((ulong)(node1?.BitvectorSize))
            {
                case 0:
                    node1 = this.astCtxt.bv(0x0000000d, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x756e6547, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x6c65746e, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x49656e69, dst4.BitSize);
                    break;
                case 1:
                    node1 = this.astCtxt.bv(0x000306a9, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x02100800, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x7fbae3ff, dst3.BitSize);
                    node4 = this.astCtxt.bv(0xbfebfbff, dst4.BitSize);
                    break;
                case 2:
                    node1 = this.astCtxt.bv(0x76035a01, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x00f0b2ff, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x00000000, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x00ca0000, dst4.BitSize);
                    break;
                case 3:
                    node1 = this.astCtxt.bv(0x00000000, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x00000000, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x00000000, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x00000000, dst4.BitSize);
                    break;
                case 4:
                    node1 = this.astCtxt.bv(0x1c004121, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x01c0003f, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x0000003f, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x00000000, dst4.BitSize);
                    break;
                case 5:
                    node1 = this.astCtxt.bv(0x00000040, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x00000040, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x00000003, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x00021120, dst4.BitSize);
                    break;
                case 0x80000000:
                    node1 = this.astCtxt.bv(0x80000008, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x00000000, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x00000000, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x00000000, dst4.BitSize);
                    break;
                case 0x80000001:
                    node1 = this.astCtxt.bv(0x00000000, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x00000000, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x00000001, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x28100800, dst4.BitSize);
                    break;
                case 0x80000002:
                    node1 = this.astCtxt.bv(0x20202020, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x49202020, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x6c65746e, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x20295228, dst4.BitSize);
                    break;
                case 0x80000003:
                    node1 = this.astCtxt.bv(0x65726f43, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x294d5428, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x2d376920, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x30323533, dst4.BitSize);
                    break;
                case 0x80000004:
                    node1 = this.astCtxt.bv(0x5043204d, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x20402055, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x30392e32, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x007a4847, dst4.BitSize);
                    break;
                case 0x80000005:
                    node1 = this.astCtxt.bv(0x00000000, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x00000000, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x00000000, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x00000000, dst4.BitSize);
                    break;
                case 0x80000006:
                    node1 = this.astCtxt.bv(0x00000000, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x00000000, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x01006040, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x00000000, dst4.BitSize);
                    break;
                case 0x80000007:
                    node1 = this.astCtxt.bv(0x00000000, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x00000000, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x00000000, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x00000100, dst4.BitSize);
                    break;
                case 0x80000008:
                    node1 = this.astCtxt.bv(0x00003024, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x00000000, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x00000000, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x00000000, dst4.BitSize);
                    break;
                default:
                    node1 = this.astCtxt.bv(0x00000007, dst1.BitSize);
                    node2 = this.astCtxt.bv(0x00000340, dst2.BitSize);
                    node3 = this.astCtxt.bv(0x00000340, dst3.BitSize);
                    node4 = this.astCtxt.bv(0x00000000, dst4.BitSize);
                    break;
            }

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst1, "CPUID AX operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst2, "CPUID BX operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, dst3, "CPUID CX operation");
            var expr4 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node4, dst4, "CPUID DX operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cqo_s(Instruction inst)
        {
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RDX));
            var src = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RAX));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics - TMP = 128 bitvec (RDX:RAX) */
            var node1 = this.astCtxt.sx(BitSizes.Qword, op1);

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "Temporary variable");


            /* Create the semantics - RDX = TMP[127...64] */
            var node2 = this.astCtxt.extract(BitSizes.Dqword - 1, BitSizes.Qword, this.astCtxt.reference(expr1));

            /* Create symbolic expression */
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst, "CQO operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cwd_s(Instruction inst)
        {
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DX));
            var src = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics - TMP = 32 bitvec (DX:AX) */
            var node1 = this.astCtxt.sx(BitSizes.Word, op1);

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "Temporary variable");


            /* Create the semantics - DX = TMP[31...16] */
            var node2 = this.astCtxt.extract(BitSizes.Dword - 1, BitSizes.Word, this.astCtxt.reference(expr1));

            /* Create symbolic expression */
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst, "CWD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void cwde_s(Instruction inst)
        {
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EAX));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);

            /* Create the semantics */
            var node = this.astCtxt.sx(BitSizes.Word, this.astCtxt.extract(BitSizes.Word - 1, 0, op1));

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "CWDE operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void dec_s(Instruction inst)
        {
            var dst = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astCtxt.bv(1, dst.BitSize);

            /* Create the semantics */
            var node = this.astCtxt.bvsub(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "DEC operation");


            /* Update symbolic flags */
            this.af_s(inst, expr, dst, op1, op2);
            this.ofSub_s(inst, expr, dst, op1, op2);
            this.pf_s(inst, expr, dst);
            this.sf_s(inst, expr, dst);
            this.zf_s(inst, expr, dst);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void div_s(Instruction inst)
        {
            var src = inst.Operands[0];

            /* Create symbolic operands */
            var divisor = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            switch (src.Size)
            {

                case ByteSizes.Byte:
                    {
                        /* AX */
                        var ax = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));
                        var dividend = this.astBuilder.GetOperandAst(inst, ax);
                        /* res = AX / Source */
                        var result = this.astCtxt.bvudiv(dividend, this.astCtxt.zx(BitSizes.Byte, divisor));
                        /* mod = AX % Source */
                        var mod = this.astCtxt.bvurem(dividend, this.astCtxt.zx(BitSizes.Byte, divisor));
                        /* AH = mod */
                        /* AL = res */
                        var node = this.astCtxt.concat(
                                      this.astCtxt.extract((BitSizes.Byte - 1), 0, mod),   /* AH = mod */
                                      this.astCtxt.extract((BitSizes.Byte - 1), 0, result) /* AL = res */
                                    );
                        /* Create symbolic expression */
                        var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, ax, "DIV operation");
                        break;
                    }

                case ByteSizes.Word:
                    {
                        /* DX:AX */
                        var dx = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DX));
                        var ax = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));
                        var dividend = this.astCtxt.concat(this.astBuilder.GetOperandAst(inst, dx), this.astBuilder.GetOperandAst(inst, ax));
                        /* res = DX:AX / Source */
                        var result = this.astCtxt.extract((BitSizes.Word - 1), 0, this.astCtxt.bvudiv(dividend, this.astCtxt.zx(BitSizes.Word, divisor)));
                        /* mod = DX:AX % Source */
                        var mod = this.astCtxt.extract((BitSizes.Word - 1), 0, this.astCtxt.bvurem(dividend, this.astCtxt.zx(BitSizes.Word, divisor)));
                        /* Create the symbolic expression for AX */
                        var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, result, ax, "DIV operation");
                        /* Create the symbolic expression for DX */
                        var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, mod, dx, "DIV operation");
                        break;
                    }

                case ByteSizes.Dword:
                    {
                        /* EDX:EAX */
                        var edx = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EDX));
                        var eax = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EAX));
                        var dividend = this.astCtxt.concat(this.astBuilder.GetOperandAst(inst, edx), this.astBuilder.GetOperandAst(inst, eax));
                        /* res = EDX:EAX / Source */
                        var result = this.astCtxt.extract((BitSizes.Dword - 1), 0, this.astCtxt.bvudiv(dividend, this.astCtxt.zx(BitSizes.Dword, divisor)));
                        /* mod = EDX:EAX % Source */
                        var mod = this.astCtxt.extract((BitSizes.Dword - 1), 0, this.astCtxt.bvurem(dividend, this.astCtxt.zx(BitSizes.Dword, divisor)));
                        /* Create the symbolic expression for EAX */
                        var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, result, eax, "DIV operation");
                        /* Create the symbolic expression for EDX */
                        var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, mod, edx, "DIV operation");
                        break;
                    }

                case ByteSizes.Qword:
                    {
                        /* RDX:RAX */
                        var rdx = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RDX));
                        var rax = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RAX));
                        var dividend = this.astCtxt.concat(this.astBuilder.GetOperandAst(inst, rdx), this.astBuilder.GetOperandAst(inst, rax));
                        /* res = RDX:RAX / Source */
                        var result = this.astCtxt.extract((BitSizes.Qword - 1), 0, this.astCtxt.bvudiv(dividend, this.astCtxt.zx(BitSizes.Qword, divisor)));
                        /* mod = RDX:RAX % Source */
                        var mod = this.astCtxt.extract((BitSizes.Qword - 1), 0, this.astCtxt.bvurem(dividend, this.astCtxt.zx(BitSizes.Qword, divisor)));
                        /* Create the symbolic expression for RAX */
                        var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, result, rax, "DIV operation");
                        /* Create the symbolic expression for RDX */
                        var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, mod, rdx, "DIV operation");
                        break;
                    }

            }

            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void endbr32_s(Instruction inst)
        {
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void endbr64_s(Instruction inst)
        {
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void extractps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            var node = this.astCtxt.extract(BitSizes.Dword - 1, 0,
                          this.astCtxt.bvlshr(
                            op2,
                            this.astCtxt.bvmul(
                              this.astCtxt.zx(126, this.astCtxt.extract(1, 0, op3)),
                              this.astCtxt.bv(BitSizes.Dword, BitSizes.Dqword)
                            )
                          )
                        );

            switch (dst.BitSize)
            {
                case BitSizes.Dword:
                    break;
                case BitSizes.Qword:
                    node = this.astCtxt.zx(BitSizes.Dword, node);
                    break;
                default:
                    throw new Exception("extractps_s(): Invalid destination operand.");
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "EXTRACTPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void idiv_s(Instruction inst)
        {
            var src = inst.Operands[0];

            /* Create symbolic operands */
            var divisor = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            switch (src.Size)
            {

                case ByteSizes.Byte:
                    {
                        /* AX */
                        var ax = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));
                        var dividend = this.astBuilder.GetOperandAst(inst, ax);
                        /* res = AX / Source */
                        var result = this.astCtxt.bvsdiv(dividend, this.astCtxt.sx(BitSizes.Byte, divisor));
                        /* mod = AX % Source */
                        var mod = this.astCtxt.bvsmod(dividend, this.astCtxt.sx(BitSizes.Byte, divisor));
                        /* AH = mod */
                        /* AL = res */
                        var node = this.astCtxt.concat(
                                      this.astCtxt.extract((BitSizes.Byte - 1), 0, mod),   /* AH = mod */
                                      this.astCtxt.extract((BitSizes.Byte - 1), 0, result) /* AL = res */
                                    );
                        /* Create symbolic expression */
                        var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, ax, "IDIV operation");
                        break;
                    }

                case ByteSizes.Word:
                    {
                        /* DX:AX */
                        var dx = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DX));
                        var ax = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));
                        var dividend = this.astCtxt.concat(this.astBuilder.GetOperandAst(inst, dx), this.astBuilder.GetOperandAst(inst, ax));
                        /* res = DX:AX / Source */
                        var result = this.astCtxt.extract((BitSizes.Word - 1), 0, this.astCtxt.bvsdiv(dividend, this.astCtxt.sx(BitSizes.Word, divisor)));
                        /* mod = DX:AX % Source */
                        var mod = this.astCtxt.extract((BitSizes.Word - 1), 0, this.astCtxt.bvsmod(dividend, this.astCtxt.sx(BitSizes.Word, divisor)));
                        /* Create the symbolic expression for AX */
                        var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, result, ax, "IDIV operation");
                        /* Create the symbolic expression for DX */
                        var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, mod, dx, "IDIV operation");
                        break;
                    }

                case ByteSizes.Dword:
                    {
                        /* EDX:EAX */
                        var edx = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EDX));
                        var eax = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EAX));
                        var dividend = this.astCtxt.concat(this.astBuilder.GetOperandAst(inst, edx), this.astBuilder.GetOperandAst(inst, eax));
                        /* res = EDX:EAX / Source */
                        var result = this.astCtxt.extract((BitSizes.Dword - 1), 0, this.astCtxt.bvsdiv(dividend, this.astCtxt.sx(BitSizes.Dword, divisor)));
                        /* mod = EDX:EAX % Source */
                        var mod = this.astCtxt.extract((BitSizes.Dword - 1), 0, this.astCtxt.bvsmod(dividend, this.astCtxt.sx(BitSizes.Dword, divisor)));
                        /* Create the symbolic expression for EAX */
                        var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, result, eax, "IDIV operation");
                        /* Create the symbolic expression for EDX */
                        var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, mod, edx, "IDIV operation");
                        break;
                    }

                case ByteSizes.Qword:
                    {
                        /* RDX:RAX */
                        var rdx = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RDX));
                        var rax = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RAX));
                        var dividend = this.astCtxt.concat(this.astBuilder.GetOperandAst(inst, rdx), this.astBuilder.GetOperandAst(inst, rax));
                        /* res = RDX:RAX / Source */
                        var result = this.astCtxt.extract((BitSizes.Qword - 1), 0, this.astCtxt.bvsdiv(dividend, this.astCtxt.sx(BitSizes.Qword, divisor)));
                        /* mod = RDX:RAX % Source */
                        var mod = this.astCtxt.extract((BitSizes.Qword - 1), 0, this.astCtxt.bvsmod(dividend, this.astCtxt.sx(BitSizes.Qword, divisor)));
                        /* Create the symbolic expression for RAX */
                        var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, result, rax, "IDIV operation");
                        /* Create the symbolic expression for RDX */
                        var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, mod, rdx, "IDIV operation");
                        break;
                    }

            }

            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void imul_s(Instruction inst)
        {
            switch (inst.Operands.Count())
            {

                /* one operand */
                case 1:
                    {
                        var src = inst.Operands[0];

                        /* size of the Operand */
                        switch (src.Size)
                        {

                            /* dst = AX */
                            case ByteSizes.Byte:
                                {
                                    var ax = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));
                                    var al = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AL));
                                    var op1 = this.astBuilder.GetOperandAst(inst, al);
                                    var op2 = this.astBuilder.GetOperandAst(inst, src);
                                    var node = this.astCtxt.bvmul(this.astCtxt.sx(BitSizes.Byte, op1), this.astCtxt.sx(BitSizes.Byte, op2));
                                    var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, ax, "IMUL operation");
                                    this.cfImul_s(inst, expr, al, this.astCtxt.bvmul(op1, op2), node);
                                    this.ofImul_s(inst, expr, al, this.astCtxt.bvmul(op1, op2), node);
                                    break;
                                }

                            /* dst = DX:AX */
                            case ByteSizes.Word:
                                {
                                    var ax = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));
                                    var dx = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DX));
                                    var op1 = this.astBuilder.GetOperandAst(inst, ax);
                                    var op2 = this.astBuilder.GetOperandAst(inst, src);
                                    var node1 = this.astCtxt.bvmul(op1, op2);
                                    var node2 = this.astCtxt.bvmul(this.astCtxt.sx(BitSizes.Word, op1), this.astCtxt.sx(BitSizes.Word, op2));
                                    var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, ax, "IMUL operation");
                                    var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, this.astCtxt.extract(BitSizes.Dword - 1, BitSizes.Word, node2), dx, "IMUL operation");
                                    this.cfImul_s(inst, expr1, ax, node1, node2);
                                    this.ofImul_s(inst, expr1, ax, node1, node2);
                                    break;
                                }

                            /* dst = EDX:EAX */
                            case ByteSizes.Dword:
                                {
                                    var eax = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EAX));
                                    var edx = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EDX));
                                    var op1 = this.astBuilder.GetOperandAst(inst, eax);
                                    var op2 = this.astBuilder.GetOperandAst(inst, src);
                                    var node1 = this.astCtxt.bvmul(op1, op2);
                                    var node2 = this.astCtxt.bvmul(this.astCtxt.sx(BitSizes.Dword, op1), this.astCtxt.sx(BitSizes.Dword, op2));
                                    var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, eax, "IMUL operation");
                                    var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, this.astCtxt.extract(BitSizes.Qword - 1, BitSizes.Dword, node2), edx, "IMUL operation");
                                    this.cfImul_s(inst, expr1, eax, node1, node2);
                                    this.ofImul_s(inst, expr1, eax, node1, node2);
                                    break;
                                }

                            /* dst = RDX:RAX */
                            case ByteSizes.Qword:
                                {
                                    var rax = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RAX));
                                    var rdx = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RDX));
                                    var op1 = this.astBuilder.GetOperandAst(inst, rax);
                                    var op2 = this.astBuilder.GetOperandAst(inst, src);
                                    var node1 = this.astCtxt.bvmul(op1, op2);
                                    var node2 = this.astCtxt.bvmul(this.astCtxt.sx(BitSizes.Qword, op1), this.astCtxt.sx(BitSizes.Qword, op2));
                                    var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, rax, "IMUL operation");
                                    var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, this.astCtxt.extract(BitSizes.Dqword - 1, BitSizes.Qword, node2), rdx, "IMUL operation");
                                    this.cfImul_s(inst, expr1, rax, node1, node2);
                                    this.ofImul_s(inst, expr1, rax, node1, node2);
                                    break;
                                }

                        }
                        break;
                    }

                /* two operands */
                case 2:
                    {
                        var dst = inst.Operands[0];
                        var src = inst.Operands[1];
                        var op1 = this.astBuilder.GetOperandAst(inst, dst);
                        var op2 = this.astBuilder.GetOperandAst(inst, src);
                        var node1 = this.astCtxt.bvmul(op1, op2);
                        var node2 = this.astCtxt.bvmul(this.astCtxt.sx(dst.BitSize, op1), this.astCtxt.sx(src.BitSize, op2));
                        var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "IMUL operation");
                        this.cfImul_s(inst, expr, dst, node1, node2);
                        this.ofImul_s(inst, expr, dst, node1, node2);
                        break;
                    }

                /* three operands */
                case 3:
                    {
                        var dst = inst.Operands[0];
                        var src1 = inst.Operands[1];
                        var src2 = inst.Operands[2];
                        var op2 = this.astBuilder.GetOperandAst(inst, src1);
                        var op3 = this.astCtxt.sx(src1.BitSize - src2.BitSize, this.astBuilder.GetOperandAst(inst, src2));
                        var node1 = this.astCtxt.bvmul(op2, op3);
                        var node2 = this.astCtxt.bvmul(this.astCtxt.sx(src1.BitSize, op2), this.astCtxt.sx(src2.BitSize, op3));
                        var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "IMUL operation");
                        this.cfImul_s(inst, expr, dst, node1, node2);
                        this.ofImul_s(inst, expr, dst, node1, node2);
                        break;
                    }

            }

            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void inc_s(Instruction inst)
        {
            var dst = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astCtxt.bv(1, dst.BitSize);

            /* Create the semantics */
            var node = this.astCtxt.bvadd(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "INC operation");


            /* Update symbolic flags */
            this.af_s(inst, expr, dst, op1, op2);
            this.ofAdd_s(inst, expr, dst, op1, op2);
            this.pf_s(inst, expr, dst);
            this.sf_s(inst, expr, dst);
            this.zf_s(inst, expr, dst);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void invd_s(Instruction inst)
        {
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void invlpg_s(Instruction inst)
        {
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void ja_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, cf);
            var op2 = this.astBuilder.GetOperandAst(inst, zf);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op4 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            this.astCtxt.bvand(
                              this.astCtxt.bvnot(op1),
                              this.astCtxt.bvnot(op2)
                            ),
                            this.astCtxt.bvtrue()
                          ), op4, op3);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jae_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, cf);
            var op2 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op1, this.astCtxt.bvfalse()), op3, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jb_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, cf);
            var op2 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op1, this.astCtxt.bvtrue()), op3, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jbe_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, cf);
            var op2 = this.astBuilder.GetOperandAst(inst, zf);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op4 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.bvor(op1, op2), this.astCtxt.bvtrue()), op4, op3);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jcxz_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var cx = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CX));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, cx);
            var op2 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm2);

            var node = this.astCtxt.ite(this.astCtxt.equal(op1, this.astCtxt.bv(0, BitSizes.Word)), op3, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void je_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, zf);
            var op2 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op1, this.astCtxt.bvtrue()), op3, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jecxz_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var ecx = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ECX));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, ecx);
            var op2 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm2);

            var node = this.astCtxt.ite(this.astCtxt.equal(op1, this.astCtxt.bv(0, BitSizes.Dword)), op3, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jg_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, sf);
            var op2 = this.astBuilder.GetOperandAst(inst, of);
            var op3 = this.astBuilder.GetOperandAst(inst, zf);
            var op4 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op5 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.bvor(this.astCtxt.bvxor(op1, op2), op3), this.astCtxt.bvfalse()), op5, op4);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jge_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, sf);
            var op2 = this.astBuilder.GetOperandAst(inst, of);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op4 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op1, op2), op4, op3);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jl_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, sf);
            var op2 = this.astBuilder.GetOperandAst(inst, of);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op4 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.bvxor(op1, op2), this.astCtxt.bvtrue()), op4, op3);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jle_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, sf);
            var op2 = this.astBuilder.GetOperandAst(inst, of);
            var op3 = this.astBuilder.GetOperandAst(inst, zf);
            var op4 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op5 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.bvor(this.astCtxt.bvxor(op1, op2), op3), this.astCtxt.bvtrue()), op5, op4);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jmp_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var src = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = op1;

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jne_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, zf);
            var op2 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op1, this.astCtxt.bvfalse()), op3, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jno_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, of);
            var op2 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op1, this.astCtxt.bvfalse()), op3, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jnp_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var pf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, pf);
            var op2 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op1, this.astCtxt.bvfalse()), op3, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jns_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, sf);
            var op2 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op1, this.astCtxt.bvfalse()), op3, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jo_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, of);
            var op2 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op1, this.astCtxt.bvtrue()), op3, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jp_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var pf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, pf);
            var op2 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op1, this.astCtxt.bvtrue()), op3, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void jrcxz_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var rcx = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RCX));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, rcx);
            var op2 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm2);

            var node = this.astCtxt.ite(this.astCtxt.equal(op1, this.astCtxt.bv(0, BitSizes.Qword)), op3, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void js_s(Instruction inst)
        {
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var srcImm1 = new OperandWrapper(new Immediate(inst.NextAddress, pc.Size));
            var srcImm2 = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, sf);
            var op2 = this.astBuilder.GetOperandAst(inst, srcImm1);
            var op3 = this.astBuilder.GetOperandAst(inst, srcImm2);

            /* Create the semantics */
            var node = this.astCtxt.ite(this.astCtxt.equal(op1, this.astCtxt.bvtrue()), op3, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");

            /* Set condition flag */


            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void lahf_s(Instruction inst)
        {
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AH));
            var src1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var src2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));
            var src3 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            var src4 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            var src5 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);
            var op3 = this.astBuilder.GetOperandAst(inst, src3);
            var op4 = this.astBuilder.GetOperandAst(inst, src4);
            var op5 = this.astBuilder.GetOperandAst(inst, src5);

            /* Create the semantics */
            List<AbstractNode> flags = new List<AbstractNode>();

            flags.Add(op1);
            flags.Add(op2);
            flags.Add(this.astCtxt.bvfalse());
            flags.Add(op3);
            flags.Add(this.astCtxt.bvfalse());
            flags.Add(op4);
            flags.Add(this.astCtxt.bvtrue());
            flags.Add(op5);

            var node = this.astCtxt.concat(flags);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "LAHF operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void lddqu_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "LDDQU operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void ldmxcsr_s(Instruction inst)
        {
            var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_MXCSR));
            var src = inst.Operands[0];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "LDMXCSR operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void lea_s(Instruction inst)
        {;
            var dst = inst.Operands[0].Register;
            var srcDisp = inst.Operands[1].MemoryAccess.Displacement;
            var srcBase = inst.Operands[1].MemoryAccess.BaseRegister;
            var srcIndex = inst.Operands[1].MemoryAccess.IndexRegister;
            var srcScale = inst.Operands[1].MemoryAccess.Scale;
            uint leaSize = 0;

            /* Setup LEA size */
            if (this.architecture.IsRegisterValid(srcBase))
                leaSize = srcBase.BitSize;
            else if (this.architecture.IsRegisterValid(srcIndex))
                leaSize = srcIndex.BitSize;
            else
                leaSize = srcDisp.BitSize;

            /* Create symbolic operands */

            /* Displacement */
            var op2 = this.astBuilder.GetImmediateAst(inst, srcDisp);
            if (leaSize > srcDisp.BitSize)
                op2 = this.astCtxt.zx(leaSize - srcDisp.BitSize, op2);

            /* Base */
            AbstractNode op3 = null;
            if (this.architecture.IsRegisterValid(srcBase))
                op3 = this.astBuilder.GetRegisterAst(inst, srcBase);
            else
                op3 = this.astCtxt.bv(0, leaSize);

            /* Base with PC */
            if (this.architecture.IsRegisterValid(srcBase) && (this.architecture.GetParentRegister(srcBase) == this.architecture.GetProgramCounter()))
                op3 = this.astCtxt.bvadd(op3, this.astCtxt.bv(inst.Size, leaSize));

            /* Index */
            AbstractNode op4 = null;
            if (this.architecture.IsRegisterValid(srcIndex))
                op4 = this.astBuilder.GetRegisterAst(inst, srcIndex);
            else
                op4 = this.astCtxt.bv(0, leaSize);

            /* Scale */
            var op5 = this.astBuilder.GetImmediateAst(inst, srcScale);
            if (leaSize > srcScale.BitSize)
                op5 = this.astCtxt.zx(leaSize - srcScale.BitSize, op5);

            /* Create the semantics */
            /* Effective address = Displacement + BaseReg + IndexReg * Scale */
            var node = this.astCtxt.bvadd(op2, this.astCtxt.bvadd(op3, this.astCtxt.bvmul(op4, op5)));

            if (dst.BitSize > leaSize)
                node = this.astCtxt.zx(dst.BitSize - leaSize, node);

            if (dst.BitSize < leaSize)
                node = this.astCtxt.extract(dst.High, dst.Low, node);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicRegisterAssignment(inst, node, dst, "LEA operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void leave_s(Instruction inst)
        {
            var stack = this.architecture.GetStackPointer();
            var baseReg = this.architecture.GetParentRegister(register_e.ID_REG_X86_BP);
            ((Action)(() => { }))();
            var bp1 = new OperandWrapper(new MemoryAccess() { BaseRegister = baseReg, Size = baseReg.Size });
            var bp2 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_BP));
            var sp = new OperandWrapper(stack);

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, bp2);

            /* RSP = RBP */
            var node1 = op1;

            /* Create the symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, sp, "Stack Pointer");


            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, bp1);

            /* RBP = pop() */
            var node2 = op2;

            /* Create the symbolic expression */
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, bp2, "Stack Top Pointer");


            /* Create the semantics - side effect */
            alignAddStack_s(inst, bp1.Size);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void lfence_s(Instruction inst)
        {
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void lodsb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_SI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);
            var op2 = this.astBuilder.GetOperandAst(inst, index);
            var op3 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = op1;
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op3, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op2, this.astCtxt.bv(ByteSizes.Byte, index.BitSize)),
                           this.astCtxt.bvsub(op2, this.astCtxt.bv(ByteSizes.Byte, index.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "LODSB operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index, "Index operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void lodsd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_SI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);
            var op2 = this.astBuilder.GetOperandAst(inst, index);
            var op3 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = op1;
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op3, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op2, this.astCtxt.bv(ByteSizes.Dword, index.BitSize)),
                           this.astCtxt.bvsub(op2, this.astCtxt.bv(ByteSizes.Dword, index.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "LODSD operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index, "Index operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void lodsq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_SI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);
            var op2 = this.astBuilder.GetOperandAst(inst, index);
            var op3 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = op1;
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op3, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op2, this.astCtxt.bv(ByteSizes.Qword, index.BitSize)),
                           this.astCtxt.bvsub(op2, this.astCtxt.bv(ByteSizes.Qword, index.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "LODSQ operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index, "Index operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void lodsw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_SI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);
            var op2 = this.astBuilder.GetOperandAst(inst, index);
            var op3 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = op1;
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op3, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op2, this.astCtxt.bv(ByteSizes.Word, index.BitSize)),
                           this.astCtxt.bvsub(op2, this.astCtxt.bv(ByteSizes.Word, index.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "LODSW operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index, "Index operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void loop_s(Instruction inst)
        {
            var count = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var src = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);
            var op2 = this.astBuilder.GetOperandAst(inst, count);

            /* Create the semantics */
            var node1 = this.astCtxt.ite(
                           this.astCtxt.equal(op2, this.astCtxt.bv(0, op2.BitvectorSize)),
                           this.astCtxt.bv(inst.NextAddress, pc.BitSize),
                           op1
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, pc, "Program Counter");

            /* Set condition flag */

            /* Create the semantics */
            var node2 = this.astCtxt.bvsub(op2, this.astCtxt.bv(1, op2.BitvectorSize));

            /* Create symbolic expression */
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, count, "LOOP counter operation");

            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr1);
        }


        void lzcnt_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var bvSize1 = dst.BitSize;
            var bvSize2 = src.BitSize;

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            AbstractNode node = null;
            switch (src.Size)
            {
                case ByteSizes.Byte:
                    node = this.astCtxt.ite(
                      this.astCtxt.equal(op1, this.astCtxt.bv(0, bvSize2)),
                      this.astCtxt.bv(bvSize2, bvSize1),
                      this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 1, bvSize2 - 1, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                      this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 2, bvSize2 - 2, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                      this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 3, bvSize2 - 3, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                      this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 4, bvSize2 - 4, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                      this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 5, bvSize2 - 5, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                      this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 6, bvSize2 - 6, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                      this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 7, bvSize2 - 7, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                      this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 8, bvSize2 - 8, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                      this.astCtxt.bv(8, bvSize1))))))))));
                    break;
                case ByteSizes.Word:
                    node = this.astCtxt.ite(
                        this.astCtxt.equal(op1, this.astCtxt.bv(0, bvSize2)),
                        this.astCtxt.bv(bvSize2, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 1, bvSize2 - 1, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 2, bvSize2 - 2, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 3, bvSize2 - 3, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 4, bvSize2 - 4, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 5, bvSize2 - 5, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 6, bvSize2 - 6, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 7, bvSize2 - 7, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 8, bvSize2 - 8, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 9, bvSize2 - 9, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(8, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 10, bvSize2 - 10, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(9, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 11, bvSize2 - 11, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(10, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 12, bvSize2 - 12, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(11, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 13, bvSize2 - 13, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(12, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 14, bvSize2 - 14, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(13, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 15, bvSize2 - 15, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(14, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 16, bvSize2 - 16, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(15, bvSize1),
                        this.astCtxt.bv(16, bvSize1))))))))))))))))));
                    break;
                case ByteSizes.Dword:
                    node = this.astCtxt.ite(
                        this.astCtxt.equal(op1, this.astCtxt.bv(0, bvSize2)),
                        this.astCtxt.bv(bvSize2, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 1, bvSize2 - 1, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 2, bvSize2 - 2, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 3, bvSize2 - 3, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 4, bvSize2 - 4, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 5, bvSize2 - 5, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 6, bvSize2 - 6, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 7, bvSize2 - 7, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 8, bvSize2 - 8, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 9, bvSize2 - 9, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(8, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 10, bvSize2 - 10, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(9, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 11, bvSize2 - 11, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(10, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 12, bvSize2 - 12, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(11, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 13, bvSize2 - 13, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(12, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 14, bvSize2 - 14, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(13, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 15, bvSize2 - 15, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(14, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 16, bvSize2 - 16, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(15, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 17, bvSize2 - 17, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(16, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 18, bvSize2 - 18, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(17, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 19, bvSize2 - 19, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(18, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 20, bvSize2 - 20, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(19, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 21, bvSize2 - 21, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(20, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 22, bvSize2 - 22, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(21, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 23, bvSize2 - 23, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(22, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 24, bvSize2 - 24, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(23, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 25, bvSize2 - 25, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(24, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 26, bvSize2 - 26, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(25, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 27, bvSize2 - 27, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(26, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 28, bvSize2 - 28, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(27, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 29, bvSize2 - 29, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(28, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 30, bvSize2 - 30, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(29, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 31, bvSize2 - 31, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(30, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 32, bvSize2 - 32, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(31, bvSize1),
                        this.astCtxt.bv(32, bvSize1))))))))))))))))))))))))))))))))));
                    break;
                case ByteSizes.Qword:
                    node = this.astCtxt.ite(
                        this.astCtxt.equal(op1, this.astCtxt.bv(0, bvSize2)),
                        this.astCtxt.bv(bvSize2, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 1, bvSize2 - 1, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 2, bvSize2 - 2, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 3, bvSize2 - 3, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 4, bvSize2 - 4, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 5, bvSize2 - 5, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 6, bvSize2 - 6, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 7, bvSize2 - 7, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 8, bvSize2 - 8, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 9, bvSize2 - 9, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(8, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 10, bvSize2 - 10, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(9, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 11, bvSize2 - 11, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(10, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 12, bvSize2 - 12, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(11, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 13, bvSize2 - 13, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(12, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 14, bvSize2 - 14, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(13, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 15, bvSize2 - 15, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(14, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 16, bvSize2 - 16, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(15, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 17, bvSize2 - 17, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(16, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 18, bvSize2 - 18, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(17, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 19, bvSize2 - 19, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(18, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 20, bvSize2 - 20, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(19, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 21, bvSize2 - 21, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(20, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 22, bvSize2 - 22, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(21, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 23, bvSize2 - 23, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(22, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 24, bvSize2 - 24, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(23, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 25, bvSize2 - 25, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(24, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 26, bvSize2 - 26, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(25, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 27, bvSize2 - 27, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(26, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 28, bvSize2 - 28, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(27, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 29, bvSize2 - 29, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(28, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 30, bvSize2 - 30, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(29, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 31, bvSize2 - 31, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(30, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 32, bvSize2 - 32, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(31, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 33, bvSize2 - 33, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(32, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 34, bvSize2 - 34, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(33, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 35, bvSize2 - 35, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(34, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 36, bvSize2 - 36, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(35, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 37, bvSize2 - 37, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(36, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 38, bvSize2 - 38, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(37, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 39, bvSize2 - 39, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(38, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 40, bvSize2 - 40, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(39, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 41, bvSize2 - 41, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(40, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 42, bvSize2 - 42, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(41, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 43, bvSize2 - 43, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(42, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 44, bvSize2 - 44, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(43, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 45, bvSize2 - 45, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(44, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 46, bvSize2 - 46, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(45, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 47, bvSize2 - 47, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(46, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 48, bvSize2 - 48, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(47, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 49, bvSize2 - 49, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(48, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 50, bvSize2 - 50, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(49, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 51, bvSize2 - 51, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(50, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 52, bvSize2 - 52, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(51, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 53, bvSize2 - 53, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(52, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 54, bvSize2 - 54, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(53, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 55, bvSize2 - 55, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(54, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 56, bvSize2 - 56, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(55, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 57, bvSize2 - 57, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(56, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 58, bvSize2 - 58, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(57, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 59, bvSize2 - 59, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(58, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 60, bvSize2 - 60, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(59, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 61, bvSize2 - 61, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(60, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 62, bvSize2 - 62, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(61, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 63, bvSize2 - 63, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(62, bvSize1),
                        this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(bvSize2 - 64, bvSize2 - 64, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(63, bvSize1),
                        this.astCtxt.bv(64, bvSize1))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))));
                    break;
                default:
                    throw new Exception("lzcnt_s(): Invalid operand size.");
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "LZCNT operation");


            /* Update symbolic flags */
            this.cfLzcnt_s(inst, expr, src, op1);
            this.zf_s(inst, expr, src);

            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void mfence_s(Instruction inst)
        {
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void mov_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            bool undef = false;

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /*
             * Special cases:
             *
             * Triton defines segment registers as 32 or 64  bits vector to
             * avoid to simulate the GDT which allows users to directly define
             * their segments offset.
             *
             * The code below, handles the case: MOV r/m{16/32/64}, Sreg
             */
            if (src.Type == OperandType.Reg)
            {
                uint id = (uint)src.Register.Id;
                if (id >= (uint)register_e.ID_REG_X86_CS && id <= (uint)register_e.ID_REG_X86_SS)
                {
                    node = this.astCtxt.extract(dst.BitSize - 1, 0, node);
                }
                if (id >= (uint)register_e.ID_REG_X86_CR0 && id <= (uint)register_e.ID_REG_X86_CR15)
                {
                    undef = true;
                }
            }

            /*
             * The code below, handles the case: MOV Sreg, r/m{16/32/64}
             */
            if (dst.Type == OperandType.Reg)
            {
                uint id = (uint)dst.Register.Id;
                if (id >= (uint)register_e.ID_REG_X86_CS && id <= (uint)register_e.ID_REG_X86_SS)
                {
                    node = this.astCtxt.extract(BitSizes.Word - 1, 0, node);
                }
                if (id >= (uint)register_e.ID_REG_X86_CR0 && id <= (uint)register_e.ID_REG_X86_CR15)
                {
                    undef = true;
                }
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOV operation");


            /* Tag undefined flags */
            if (undef)
            {
                this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
                this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF));
                this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));
                this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
                this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));
                this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_ZF));
            }

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movabs_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVABS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movapd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVAPD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movaps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVAPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movbe_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> exprs = new List<AbstractNode>();
            for (uint i = 0; i < src.Size; ++i)
            {
                exprs.Add(this.astCtxt.extract(BitSizes.Byte * i + (BitSizes.Byte - 1),
                                                       BitSizes.Byte * i,
                                                       op));
            }
            var node = this.astCtxt.concat(exprs);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVBE operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            AbstractNode node = null;

            switch (dst.BitSize)
            {
                /* GPR 32-bits */
                case BitSizes.Dword:
                    node = this.astCtxt.extract(BitSizes.Dword - 1, 0, op2);
                    break;

                /* MMX 64-bits */
                case BitSizes.Qword:
                    node = this.astCtxt.zx(BitSizes.Dword, this.astCtxt.extract(BitSizes.Dword - 1, 0, op2));
                    break;

                /* XMM 128-bits */
                case BitSizes.Dqword:
                    node = this.astCtxt.zx(BitSizes.Qword + BitSizes.Dword, this.astCtxt.extract(BitSizes.Dword - 1, 0, op2));
                    break;
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movddup_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.concat(this.astCtxt.extract(BitSizes.Qword - 1, 0, op2), this.astCtxt.extract(BitSizes.Qword - 1, 0, op2));

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVDDUP operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movdq2q_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.extract(BitSizes.Qword - 1, 0, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVDQ2Q operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movdqa_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVDQA operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movdqu_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVDQU operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movhlps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.concat(
                          this.astCtxt.extract((BitSizes.Dqword - 1), BitSizes.Qword, op1), /* Destination[127..64] unchanged */
                          this.astCtxt.extract((BitSizes.Dqword - 1), BitSizes.Qword, op2)  /* Destination[63..0] = Source[127..64]; */
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVHLPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movhpd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            AbstractNode node = null;

            /* xmm, m64 */
            if (dst.Size == ByteSizes.Dqword)
            {
                node = this.astCtxt.concat(
                         this.astCtxt.extract((BitSizes.Qword - 1), 0, op2), /* Destination[127..64] = Source */
                         this.astCtxt.extract((BitSizes.Qword - 1), 0, op1)  /* Destination[63..0] unchanged */
                       );
            }

            /* m64, xmm */
            else
            {
                node = this.astCtxt.extract((BitSizes.Dqword - 1), BitSizes.Qword, op2); /* Destination[63..00] = Source[127..64] */
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVHPD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movhps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            AbstractNode node = null;

            /* xmm, m64 */
            if (dst.Size == ByteSizes.Dqword)
            {
                node = this.astCtxt.concat(
                         this.astCtxt.extract((BitSizes.Qword - 1), 0, op2), /* Destination[127..64] = Source */
                         this.astCtxt.extract((BitSizes.Qword - 1), 0, op1)  /* Destination[63..0] unchanged */
                       );
            }

            /* m64, xmm */
            else
            {
                node = this.astCtxt.extract((BitSizes.Dqword - 1), BitSizes.Qword, op2); /* Destination[63..00] = Source[127..64] */
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVHPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movlhps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.concat(
                          this.astCtxt.extract((BitSizes.Qword - 1), 0, op2), /* Destination[127..64] = Source[63..0] */
                          this.astCtxt.extract((BitSizes.Qword - 1), 0, op1)  /* Destination[63..0] unchanged */
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVLHPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movlpd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            AbstractNode node = null;

            /* xmm, m64 */
            if (dst.Size == ByteSizes.Dqword)
            {
                node = this.astCtxt.concat(
                         this.astCtxt.extract((BitSizes.Dqword - 1), BitSizes.Qword, op1), /* Destination[127..64] unchanged */
                         this.astCtxt.extract((BitSizes.Qword - 1), 0, op2)                /* Destination[63..0] = Source */
                       );
            }

            /* m64, xmm */
            else
            {
                node = this.astCtxt.extract((BitSizes.Qword - 1), 0, op2); /* Destination = Source[63..00] */
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVLPD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movlps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            AbstractNode node = null;

            /* xmm, m64 */
            if (dst.Size == ByteSizes.Dqword)
            {
                node = this.astCtxt.concat(
                         this.astCtxt.extract((BitSizes.Dqword - 1), BitSizes.Qword, op1), /* Destination[127..64] unchanged */
                         this.astCtxt.extract((BitSizes.Qword - 1), 0, op2)                /* Destination[63..0] = Source */
                       );
            }

            /* m64, xmm */
            else
            {
                node = this.astCtxt.extract((BitSizes.Qword - 1), 0, op2); /* Destination = Source[63..00] */
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVLPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movmskpd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.zx(30,                       /* Destination[2..31] = 0        */
                          this.astCtxt.concat(
                            this.astCtxt.extract(127, 127, op2),  /* Destination[1] = Source[127]; */
                            this.astCtxt.extract(63, 63, op2)     /* Destination[0] = Source[63];  */
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVMSKPD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movmskps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> signs = new List<AbstractNode>();

            signs.Add(this.astCtxt.extract(127, 127, op2)); /* Destination[3] = Source[127]; */
            signs.Add(this.astCtxt.extract(95, 95, op2)); /* Destination[2] = Source[95];  */
            signs.Add(this.astCtxt.extract(63, 63, op2)); /* Destination[1] = Source[63];  */
            signs.Add(this.astCtxt.extract(31, 31, op2)); /* Destination[0] = Source[31];  */

            var node = this.astCtxt.zx(28, this.astCtxt.concat(signs));

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVMSKPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movntdq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVNTDQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movnti_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVNTI operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movntpd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVNTPD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movntps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVNTPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movntq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVNTQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movshdup_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> bytes = new List<AbstractNode>();

            bytes.Add(this.astCtxt.extract(127, 96, op2));
            bytes.Add(this.astCtxt.extract(127, 96, op2));
            bytes.Add(this.astCtxt.extract(63, 32, op2));
            bytes.Add(this.astCtxt.extract(63, 32, op2));

            var node = this.astCtxt.concat(bytes);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVSHDUP operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movsldup_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> bytes = new List<AbstractNode>();

            bytes.Add(this.astCtxt.extract(95, 64, op2));
            bytes.Add(this.astCtxt.extract(95, 64, op2));
            bytes.Add(this.astCtxt.extract(31, 0, op2));
            bytes.Add(this.astCtxt.extract(31, 0, op2));

            var node = this.astCtxt.concat(bytes);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVSLDUP operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            AbstractNode node = null;

            /* when operating on MMX technology registers and memory locations */
            if (dst.BitSize == BitSizes.Qword && src.BitSize == BitSizes.Qword)
                node = op2;

            /* when source and destination operands are XMM registers */
            else if (dst.BitSize == BitSizes.Dqword && src.BitSize == BitSizes.Dqword)
                node = this.astCtxt.concat(
                        this.astCtxt.extract(BitSizes.Dqword - 1, BitSizes.Qword, op1),
                        this.astCtxt.extract(BitSizes.Qword - 1, 0, op2)
                       );

            /* when source operand is XMM register and destination operand is memory location */
            else if (dst.BitSize < src.BitSize)
                node = this.astCtxt.extract(BitSizes.Qword - 1, 0, op2);

            /* when source operand is memory location and destination operand is XMM register */
            else if (dst.BitSize > src.BitSize)
                node = this.astCtxt.zx(BitSizes.Qword, op2);

            /* Invalid operation */
            else
                throw new Exception("movq_s(): Invalid operation.");

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movq2dq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.zx(BitSizes.Qword, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVQ2DQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movsb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index1 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var index2 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_SI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);
            var op2 = this.astBuilder.GetOperandAst(inst, index1);
            var op3 = this.astBuilder.GetOperandAst(inst, index2);
            var op4 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = op1;
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op4, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op2, this.astCtxt.bv(ByteSizes.Byte, index1.BitSize)),
                           this.astCtxt.bvsub(op2, this.astCtxt.bv(ByteSizes.Byte, index1.BitSize))
                         );
            var node3 = this.astCtxt.ite(
                           this.astCtxt.equal(op4, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op3, this.astCtxt.bv(ByteSizes.Byte, index2.BitSize)),
                           this.astCtxt.bvsub(op3, this.astCtxt.bv(ByteSizes.Byte, index2.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "MOVSB operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index1, "Index (DI) operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, index2, "Index (SI) operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movsd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index1 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var index2 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_SI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /*
             * F2 0F 10 /r MOVSD xmm1, xmm2
             * F2 0F 10 /r MOVSD xmm1, m64
             */
            if (dst.BitSize == BitSizes.Dqword)
            {
                var op1 = this.astBuilder.GetOperandAst(inst, src);
                var op2 = this.astBuilder.GetOperandAst(dst);

                var node = this.astCtxt.concat(
                              this.astCtxt.extract(127, 64, op2),
                              this.astCtxt.extract(63, 0, op1)
                            );

                var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVSD operation");
            }

            /*
             * F2 0F 11 /r MOVSD m64, xmm2
             */
            else if (dst.BitSize == BitSizes.Qword && src.BitSize == BitSizes.Dqword)
            {
                var op1 = this.astBuilder.GetOperandAst(inst, src);
                var node = this.astCtxt.extract(63, 0, op1);
                var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVSD operation");
            }

            /* A5 MOVSD */
            else
            {
                /* Create symbolic operands */
                var op1 = this.astBuilder.GetOperandAst(inst, src);
                var op2 = this.astBuilder.GetOperandAst(inst, index1);
                var op3 = this.astBuilder.GetOperandAst(inst, index2);
                var op4 = this.astBuilder.GetOperandAst(inst, df);

                /* Create the semantics */
                var node1 = op1;
                var node2 = this.astCtxt.ite(
                               this.astCtxt.equal(op4, this.astCtxt.bvfalse()),
                               this.astCtxt.bvadd(op2, this.astCtxt.bv(ByteSizes.Dword, index1.BitSize)),
                               this.astCtxt.bvsub(op2, this.astCtxt.bv(ByteSizes.Dword, index1.BitSize))
                             );
                var node3 = this.astCtxt.ite(
                               this.astCtxt.equal(op4, this.astCtxt.bvfalse()),
                               this.astCtxt.bvadd(op3, this.astCtxt.bv(ByteSizes.Dword, index2.BitSize)),
                               this.astCtxt.bvsub(op3, this.astCtxt.bv(ByteSizes.Dword, index2.BitSize))
                             );

                /* Create symbolic expression */
                var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "MOVSD operation");
                var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index1, "Index (DI) operation");
                var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, index2, "Index (SI) operation");

            }

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movupd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVUPD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movups_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVUPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movss_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = op;
            if (src.Type == OperandType.Reg)
            {
                node = this.astCtxt.extract(BitSizes.Dword - 1, 0, node);
                if (dst.Type == OperandType.Reg)
                {
                    var op1 = this.astBuilder.GetOperandAst(inst, dst);
                    var upper = this.astCtxt.extract(BitSizes.Dqword - 1, BitSizes.Dword, op1);
                    node = this.astCtxt.concat(upper, node);
                }
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVSS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movsq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index1 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var index2 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_SI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);
            var op2 = this.astBuilder.GetOperandAst(inst, index1);
            var op3 = this.astBuilder.GetOperandAst(inst, index2);
            var op4 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = op1;
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op4, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op2, this.astCtxt.bv(ByteSizes.Qword, index1.BitSize)),
                           this.astCtxt.bvsub(op2, this.astCtxt.bv(ByteSizes.Qword, index1.BitSize))
                         );
            var node3 = this.astCtxt.ite(
                           this.astCtxt.equal(op4, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op3, this.astCtxt.bv(ByteSizes.Qword, index2.BitSize)),
                           this.astCtxt.bvsub(op3, this.astCtxt.bv(ByteSizes.Qword, index2.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "MOVSQ operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index1, "Index (DI) operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, index2, "Index (SI) operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movsw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index1 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var index2 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_SI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);
            var op2 = this.astBuilder.GetOperandAst(inst, index1);
            var op3 = this.astBuilder.GetOperandAst(inst, index2);
            var op4 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = op1;
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op4, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op2, this.astCtxt.bv(ByteSizes.Word, index1.BitSize)),
                           this.astCtxt.bvsub(op2, this.astCtxt.bv(ByteSizes.Word, index1.BitSize))
                         );
            var node3 = this.astCtxt.ite(
                           this.astCtxt.equal(op4, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op3, this.astCtxt.bv(ByteSizes.Word, index2.BitSize)),
                           this.astCtxt.bvsub(op3, this.astCtxt.bv(ByteSizes.Word, index2.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "MOVSW operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index1, "Index (DI) operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, index2, "Index (SI) operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movsx_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.sx(dst.BitSize - src.BitSize, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVSX operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movsxd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.sx(dst.BitSize - src.BitSize, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVSXD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void movzx_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.zx(dst.BitSize - src.BitSize, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MOVZX operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void mul_s(Instruction inst)
        {
            var src2 = inst.Operands[0];

            switch (src2.Size)
            {

                /* AX = AL * r/m8 */
                case ByteSizes.Byte:
                    {
                        var dst = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));
                        var src1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AL));
                        /* Create symbolic operands */
                        var op1 = this.astBuilder.GetOperandAst(inst, src1);
                        var op2 = this.astBuilder.GetOperandAst(inst, src2);
                        /* Create the semantics */
                        var node = this.astCtxt.bvmul(this.astCtxt.zx(BitSizes.Byte, op1), this.astCtxt.zx(BitSizes.Byte, op2));
                        /* Create symbolic expression */
                        var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "MUL operation");
                        /* Update symbolic flags */
                        var ah = this.astCtxt.extract((BitSizes.Word - 1), BitSizes.Byte, node);
                        this.cfMul_s(inst, expr, src2, ah);
                        this.ofMul_s(inst, expr, src2, ah);
                        break;
                    }

                /* DX:AX = AX * r/m16 */
                case ByteSizes.Word:
                    {
                        var dst1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));
                        var dst2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DX));
                        var src1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AX));
                        /* Create symbolic operands */
                        var op1 = this.astBuilder.GetOperandAst(inst, src1);
                        var op2 = this.astBuilder.GetOperandAst(inst, src2);
                        /* Create symbolic expression for ax */
                        var ax = this.astCtxt.bvmul(op1, op2);
                        var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, ax, dst1, "MUL operation");
                        /* Create symbolic expression for dx */
                        var node = this.astCtxt.bvmul(this.astCtxt.zx(BitSizes.Word, op1), this.astCtxt.zx(BitSizes.Word, op2));
                        var dx = this.astCtxt.extract((BitSizes.Dword - 1), BitSizes.Word, node);
                        var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, dx, dst2, "MUL operation");
                        /* Update symbolic flags */
                        this.cfMul_s(inst, expr2, src2, dx);
                        this.ofMul_s(inst, expr2, src2, dx);
                        break;
                    }

                /* EDX:EAX = EAX * r/m32 */
                case ByteSizes.Dword:
                    {
                        var dst1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EAX));
                        var dst2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EDX));
                        var src1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EAX));
                        /* Create symbolic operands */
                        var op1 = this.astBuilder.GetOperandAst(inst, src1);
                        var op2 = this.astBuilder.GetOperandAst(inst, src2);
                        /* Create symbolic expression for eax */
                        var eax = this.astCtxt.bvmul(op1, op2);
                        var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, eax, dst1, "MUL operation");
                        /* Create symbolic expression for edx */
                        var node = this.astCtxt.bvmul(this.astCtxt.zx(BitSizes.Dword, op1), this.astCtxt.zx(BitSizes.Dword, op2));
                        var edx = this.astCtxt.extract((BitSizes.Qword - 1), BitSizes.Dword, node);
                        var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, edx, dst2, "MUL operation");
                        /* Update symbolic flags */
                        this.cfMul_s(inst, expr2, src2, edx);
                        this.ofMul_s(inst, expr2, src2, edx);
                        break;
                    }

                /* RDX:RAX = RAX * r/m64 */
                case ByteSizes.Qword:
                    {
                        var dst1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RAX));
                        var dst2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RDX));
                        var src1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RAX));
                        /* Create symbolic operands */
                        var op1 = this.astBuilder.GetOperandAst(inst, src1);
                        var op2 = this.astBuilder.GetOperandAst(inst, src2);
                        /* Create the semantics */
                        /* Create symbolic expression for eax */
                        var rax = this.astCtxt.bvmul(op1, op2);
                        var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, rax, dst1, "MUL operation");
                        /* Create symbolic expression for rdx */
                        var node = this.astCtxt.bvmul(this.astCtxt.zx(BitSizes.Qword, op1), this.astCtxt.zx(BitSizes.Qword, op2));
                        var rdx = this.astCtxt.extract((BitSizes.Dqword - 1), BitSizes.Qword, node);
                        var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, rdx, dst2, "MUL operation");
                        /* Update symbolic flags */
                        this.cfMul_s(inst, expr2, src2, rdx);
                        this.ofMul_s(inst, expr2, src2, rdx);
                        break;
                    }

            }

            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void mulx_s(Instruction inst)
        {
            switch (inst.Operands[0].Size)
            {

                /* r32a, r32b, r/m32 */
                case ByteSizes.Dword:
                    {
                        var dst1 = inst.Operands[0];
                        var dst2 = inst.Operands[1];
                        var src1 = inst.Operands[2];
                        var src2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EDX));

                        /* Create symbolic operands */
                        var op1 = this.astBuilder.GetOperandAst(inst, src1);
                        var op2 = this.astBuilder.GetOperandAst(inst, src2);

                        /* Create the semantics */
                        var node = this.astCtxt.bvmul(this.astCtxt.zx(BitSizes.Dword, op1), this.astCtxt.zx(BitSizes.Dword, op2));
                        var node1 = this.astCtxt.bvmul(op1, op2);
                        var node2 = this.astCtxt.extract((BitSizes.Qword - 1), BitSizes.Dword, node);

                        /* Create symbolic expression */
                        var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst2, "MULX operation");
                        var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst1, "MULX operation");


                        break;
                    }

                /* r64a, r64b, r/m64 */
                case ByteSizes.Qword:
                    {
                        var dst1 = inst.Operands[0];
                        var dst2 = inst.Operands[1];
                        var src1 = inst.Operands[2];
                        var src2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RDX));

                        /* Create symbolic operands */
                        var op1 = this.astBuilder.GetOperandAst(inst, src1);
                        var op2 = this.astBuilder.GetOperandAst(inst, src2);

                        /* Create the semantics */
                        var node = this.astCtxt.bvmul(this.astCtxt.zx(BitSizes.Qword, op1), this.astCtxt.zx(BitSizes.Qword, op2));
                        var node1 = this.astCtxt.bvmul(op1, op2);
                        var node2 = this.astCtxt.extract((BitSizes.Dqword - 1), BitSizes.Qword, node);

                        /* Create symbolic expression for eax */
                        var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst2, "MULX operation");
                        var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst1, "MULX operation");


                        break;
                    }

            }

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void neg_s(Instruction inst)
        {
            var src = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvneg(op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, src, "NEG operation");


            /* Update symbolic flags */
            this.afNeg_s(inst, expr, src, op1);
            this.cfNeg_s(inst, expr, src, op1);
            this.ofNeg_s(inst, expr, src, op1);
            this.pf_s(inst, expr, src);
            this.sf_s(inst, expr, src);
            this.zf_s(inst, expr, src);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void nop_s(Instruction inst)
        {
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void not_s(Instruction inst)
        {
            var src = inst.Operands[0];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvnot(op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, src, "NOT operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void or_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvor(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "OR operation");


            /* Update symbolic flags */
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Clears carry flag");
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Clears overflow flag");
            this.pf_s(inst, expr, dst);
            this.sf_s(inst, expr, dst);
            this.zf_s(inst, expr, dst);

            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void orpd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvor(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "ORPD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void orps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvor(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "ORPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void packuswb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            List<AbstractNode> ops = new List<AbstractNode>() { op2, op1 };
            for (uint i = 0; i < ops.Count(); i++)
            {
                for (uint index = 0; index < dst.Size / ByteSizes.Word; index++)
                {
                    uint high = (dst.BitSize - 1) - (index * BitSizes.Word);
                    uint low = (dst.BitSize - BitSizes.Word) - (index * BitSizes.Word);
                    var signed_word = this.astCtxt.extract(high, low, ops[(int)i]);
                    pck.Add(this.astCtxt.ite(
                                   this.astCtxt.bvsge(signed_word, this.astCtxt.bv(0xff, BitSizes.Word)),
                                   this.astCtxt.bv(0xff, BitSizes.Byte),
                                   this.astCtxt.ite(
                                     this.astCtxt.bvsle(signed_word, this.astCtxt.bv(0x00, BitSizes.Word)),
                                     this.astCtxt.bv(0x00, BitSizes.Byte),
                                     this.astCtxt.extract(BitSizes.Byte - 1, 0, signed_word)))
                                 );
                }
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PACKUSWB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void paddb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> packed = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* XMM */
                case BitSizes.Dqword:
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(127, 120, op1), this.astCtxt.extract(127, 120, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(119, 112, op1), this.astCtxt.extract(119, 112, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(111, 104, op1), this.astCtxt.extract(111, 104, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(103, 96, op1), this.astCtxt.extract(103, 96, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(95, 88, op1), this.astCtxt.extract(95, 88, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(87, 80, op1), this.astCtxt.extract(87, 80, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(79, 72, op1), this.astCtxt.extract(79, 72, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(71, 64, op1), this.astCtxt.extract(71, 64, op2)));
                    goto case BitSizes.Qword;

                /* MMX */
                case BitSizes.Qword:
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(63, 56, op1), this.astCtxt.extract(63, 56, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(55, 48, op1), this.astCtxt.extract(55, 48, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(47, 40, op1), this.astCtxt.extract(47, 40, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(39, 32, op1), this.astCtxt.extract(39, 32, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(31, 24, op1), this.astCtxt.extract(31, 24, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(23, 16, op1), this.astCtxt.extract(23, 16, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(15, 8, op1), this.astCtxt.extract(15, 8, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(7, 0, op1), this.astCtxt.extract(7, 0, op2)));
                    break;

                default:
                    throw new Exception("paddb_s(): Invalid operand size.");

            }

            var node = this.astCtxt.concat(packed);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PADDB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void paddd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> packed = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* XMM */
                case BitSizes.Dqword:
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(127, 96, op1), this.astCtxt.extract(127, 96, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(95, 64, op1), this.astCtxt.extract(95, 64, op2)));
                    goto case BitSizes.Qword;

                /* MMX */
                case BitSizes.Qword:
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(63, 32, op1), this.astCtxt.extract(63, 32, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(31, 0, op1), this.astCtxt.extract(31, 0, op2)));
                    break;

                default:
                    throw new Exception("paddd_s(): Invalid operand size.");

            }

            var node = this.astCtxt.concat(packed);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PADDD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void paddq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> packed = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* XMM */
                case BitSizes.Dqword:
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(127, 64, op1), this.astCtxt.extract(127, 64, op2)));
                    goto case BitSizes.Qword;

                /* MMX */
                case BitSizes.Qword:
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(63, 0, op1), this.astCtxt.extract(63, 0, op2)));
                    break;

                default:
                    throw new Exception("paddq_s(): Invalid operand size.");

            }

            var node = this.astCtxt.concat(packed);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PADDQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void paddw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> packed = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* XMM */
                case BitSizes.Dqword:
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(127, 112, op1), this.astCtxt.extract(127, 112, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(111, 96, op1), this.astCtxt.extract(111, 96, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(95, 80, op1), this.astCtxt.extract(95, 80, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(79, 64, op1), this.astCtxt.extract(79, 64, op2)));
                    goto case BitSizes.Qword;

                /* MMX */
                case BitSizes.Qword:
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(63, 48, op1), this.astCtxt.extract(63, 48, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(47, 32, op1), this.astCtxt.extract(47, 32, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(31, 16, op1), this.astCtxt.extract(31, 16, op2)));
                    packed.Add(this.astCtxt.bvadd(this.astCtxt.extract(15, 0, op1), this.astCtxt.extract(15, 0, op2)));
                    break;

                default:
                    throw new Exception("paddw_s(): Invalid operand size.");

            }

            var node = this.astCtxt.concat(packed);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PADDW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void palignr_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var size = 2 * dst.BitSize;
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astCtxt.zx(size - src2.BitSize, this.astBuilder.GetOperandAst(inst, src2));

            /* Create the semantics */
            var node = this.astCtxt.extract(
                          dst.BitSize - 1, 0,
                          this.astCtxt.bvlshr(
                            this.astCtxt.concat(op1, op2),
                            this.astCtxt.bvmul(
                              this.astCtxt.ite(
                                this.astCtxt.bvuge(op3, this.astCtxt.bv(2 * dst.Size, size)),
                                this.astCtxt.bv(2 * dst.Size, size),
                                op3),
                              this.astCtxt.bv(BitSizes.Byte, size)
                            )));

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PALIGNR operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pand_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvand(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PAND operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pandn_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvand(this.astCtxt.bvnot(op1), op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PANDN operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pause_s(Instruction inst)
        {
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pavgb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Byte);
                uint low = (dst.BitSize - BitSizes.Byte) - (index * BitSizes.Byte);
                pck.Add(
                  this.astCtxt.extract(BitSizes.Byte - 1, 0,
                    this.astCtxt.bvlshr(
                      this.astCtxt.bvadd(
                        this.astCtxt.bvadd(
                          this.astCtxt.zx(1, this.astCtxt.extract(high, low, op1)),
                          this.astCtxt.zx(1, this.astCtxt.extract(high, low, op2))
                        ),
                        this.astCtxt.bv(1, BitSizes.Byte + 1)
                      ),
                      this.astCtxt.bv(1, BitSizes.Byte + 1)
                    )
                  )
                );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PAVGB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pavgw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Word; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Word);
                uint low = (dst.BitSize - BitSizes.Word) - (index * BitSizes.Word);
                pck.Add(
                  this.astCtxt.extract(BitSizes.Word - 1, 0,
                    this.astCtxt.bvlshr(
                      this.astCtxt.bvadd(
                        this.astCtxt.bvadd(
                          this.astCtxt.zx(1, this.astCtxt.extract(high, low, op1)),
                          this.astCtxt.zx(1, this.astCtxt.extract(high, low, op2))
                        ),
                        this.astCtxt.bv(1, BitSizes.Word + 1)
                      ),
                      this.astCtxt.bv(1, BitSizes.Word + 1)
                    )
                  )
                );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PAVGW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pcmpeqb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Byte);
                uint low = (dst.BitSize - BitSizes.Byte) - (index * BitSizes.Byte);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.equal(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.bv(0xff, BitSizes.Byte),
                                this.astCtxt.bv(0x00, BitSizes.Byte))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PCMPEQB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pcmpeqd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Dword; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Dword);
                uint low = (dst.BitSize - BitSizes.Dword) - (index * BitSizes.Dword);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.equal(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.bv(0xffffffff, BitSizes.Dword),
                                this.astCtxt.bv(0x00000000, BitSizes.Dword))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PCMPEQD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pcmpeqw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Word; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Word);
                uint low = (dst.BitSize - BitSizes.Word) - (index * BitSizes.Word);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.equal(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.bv(0xffff, BitSizes.Word),
                                this.astCtxt.bv(0x0000, BitSizes.Word))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PCMPEQW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pcmpgtb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Byte);
                uint low = (dst.BitSize - BitSizes.Byte) - (index * BitSizes.Byte);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvsgt(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.bv(0xff, BitSizes.Byte),
                                this.astCtxt.bv(0x00, BitSizes.Byte))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PCMPGTB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pcmpgtd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Dword; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Dword);
                uint low = (dst.BitSize - BitSizes.Dword) - (index * BitSizes.Dword);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvsgt(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.bv(0xffffffff, BitSizes.Dword),
                                this.astCtxt.bv(0x00000000, BitSizes.Dword))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PCMPGTD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }

        void pcmpgtw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Word; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Word);
                uint low = (dst.BitSize - BitSizes.Word) - (index * BitSizes.Word);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvsgt(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.bv(0xffff, BitSizes.Word),
                                this.astCtxt.bv(0x0000, BitSizes.Word))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PCMPGTW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmaxsb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Byte);
                uint low = (dst.BitSize - BitSizes.Byte) - (index * BitSizes.Byte);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvsle(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.extract(high, low, op2),
                                this.astCtxt.extract(high, low, op1))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMAXSB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pextrb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            var node = this.astCtxt.extract(BitSizes.Byte - 1, 0,
                          this.astCtxt.bvlshr(
                            op2,
                            this.astCtxt.bv(((op3.Evaluate() & 0x0f) * BitSizes.Byte), op2.BitvectorSize)
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PEXTRB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pextrd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            var node = this.astCtxt.extract(BitSizes.Dword - 1, 0,
                          this.astCtxt.bvlshr(
                            op2,
                            this.astCtxt.bv(((op3.Evaluate() & 0x3) * BitSizes.Dword), op2.BitvectorSize)
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PEXTRD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pextrq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            var node = this.astCtxt.extract(BitSizes.Qword - 1, 0,
                          this.astCtxt.bvlshr(
                            op2,
                            this.astCtxt.bv(((op3.Evaluate() & 0x1) * BitSizes.Qword), op2.BitvectorSize)
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PEXTRQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pextrw_s(Instruction inst)
        {
            uint count = 0;
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /*
             * When specifying a word location in an MMX technology register, the
             * 2 least-significant bits of the count operand specify the location;
             * for an XMM register, the 3 least-significant bits specify the
             * location.
             */
            if (src1.BitSize == BitSizes.Qword)
            {
                count = 0x03;
            }
            else
            {
                count = 0x07;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            var node = this.astCtxt.extract(BitSizes.Word - 1, 0,
                          this.astCtxt.bvlshr(
                            op2,
                            this.astCtxt.bv(((op3.Evaluate() & count) * BitSizes.Word), op2.BitvectorSize)
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PEXTRW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pinsrb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            // SEL  = COUNT[3:0];
            // MASK = (0FFH << (SEL * 8));
            UInt64 sel = op3.Evaluate() & 0x0f;
            UInt64 mask = 0xff;
            mask = mask << (byte)(sel * 8);

            // TEMP = ((SRC[7:0] << (SEL * 8)) AND MASK);
            var temp = this.astCtxt.bvand(
                          this.astCtxt.bvshl(
                            this.astCtxt.zx(120, this.astCtxt.extract(7, 0, op2)),
                            this.astCtxt.bv(sel * 8, 128)
                          ),
                          this.astCtxt.bv(mask, 128)
                        );

            // DEST = ((DEST AND NOT MASK) OR TEMP);
            var node = this.astCtxt.bvor(
                          this.astCtxt.bvand(
                            op1,
                            this.astCtxt.bvnot(this.astCtxt.bv(mask, 128))
                          ),
                          temp
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PINSRB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pinsrd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            // SEL  = COUNT[1:0];
            // MASK = (0FFFFFFFFH << (SEL * 32));
            UInt64 sel = op3.Evaluate() & 0x03;
            UInt64 mask = 0xffffffff;
            mask = mask << (byte)(sel * 32);

            // TEMP = ((SRC[31:0] << (SEL * 32)) AND MASK);
            var temp = this.astCtxt.bvand(
                          this.astCtxt.bvshl(
                            this.astCtxt.zx(96, this.astCtxt.extract(31, 0, op2)),
                            this.astCtxt.bv(sel * 32, 128)
                          ),
                          this.astCtxt.bv(mask, 128)
                        );

            // DEST = ((DEST AND NOT MASK) OR TEMP);
            var node = this.astCtxt.bvor(
                          this.astCtxt.bvand(
                            op1,
                            this.astCtxt.bvnot(this.astCtxt.bv(mask, 128))
                          ),
                          temp
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PINSRD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pinsrq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            // SEL  = COUNT[0:0];
            // MASK = (0FFFFFFFFFFFFFFFFH << (SEL * 64));
            UInt64 sel = op3.Evaluate() & 0x1;
            UInt64 mask = 0xffffffffffffffff;
            mask = mask << (byte)(sel * 64);

            // TEMP = ((SRC[63:0] << (SEL * 64)) AND MASK);
            var temp = this.astCtxt.bvand(
                          this.astCtxt.bvshl(
                            this.astCtxt.zx(64, this.astCtxt.extract(63, 0, op2)),
                            this.astCtxt.bv(sel * 64, 128)
                          ),
                          this.astCtxt.bv(mask, 128)
                        );

            // DEST = ((DEST AND NOT MASK) OR TEMP);
            var node = this.astCtxt.bvor(
                          this.astCtxt.bvand(
                            op1,
                            this.astCtxt.bvnot(this.astCtxt.bv(mask, 128))
                          ),
                          temp
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PINSRQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pinsrw_s(Instruction inst)
        {
            UInt64 mask = 0xffff;
            UInt64 sel = 0;
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            /*
             * PINSRW (with 64-bit source operand)
             *
             * SEL = COUNT AND 3H;
             * CASE (Determine word position) {
             *   if SEL == 0: MASK = 000000000000FFFFH;
             *   if SEL == 1: MASK = 00000000FFFF0000H;
             *   if SEL == 2: MASK = 0000FFFF00000000H;
             *   if SEL == 3: MASK = FFFF000000000000H;
             * }
             */
            if (dst.BitSize == BitSizes.Qword)
            {
                sel = op3.Evaluate() & 0x3;
                switch (sel)
                {
                    case 1: mask = mask << 16; break;
                    case 2: mask = mask << 32; break;
                    case 3: mask = mask << 48; break;
                }
            }

            /*
             * PINSRW (with 128-bit source operand)
             *
             * SEL ← COUNT AND 7H;
             * CASE (Determine word position) {
             *   SEL == 0: MASK = 0000000000000000000000000000FFFFH;
             *   SEL == 1: MASK = 000000000000000000000000FFFF0000H;
             *   SEL == 2: MASK = 00000000000000000000FFFF00000000H;
             *   SEL == 3: MASK = 0000000000000000FFFF000000000000H;
             *   SEL == 4: MASK = 000000000000FFFF0000000000000000H;
             *   SEL == 5: MASK = 00000000FFFF00000000000000000000H;
             *   SEL == 6: MASK = 0000FFFF000000000000000000000000H;
             *   SEL == 7: MASK = FFFF0000000000000000000000000000H;
             * }
             */
            else
            {
                sel = op3.Evaluate() & 0x7;
                switch (sel)
                {
                    case 1: mask = mask << 16; break;
                    case 2: mask = mask << 32; break;
                    case 3: mask = mask << 48; break;
                    case 4: mask = mask << 64; break;
                    case 5: mask = mask << 80; break;
                    case 6: mask = mask << 96; break;
                    case 7: mask = mask << 112; break;
                }
            }

            // TEMP = ((SRC << (SEL ∗ 16)) AND MASK);
            var temp = this.astCtxt.bvand(
                          this.astCtxt.bvshl(
                            this.astCtxt.zx(112, this.astCtxt.extract(15, 0, op2)),
                            this.astCtxt.bv(sel * 16, 128)
                          ),
                          this.astCtxt.bv(mask, 128)
                        );

            // DEST = ((DEST AND NOT MASK) OR TEMP);
            var node = this.astCtxt.bvor(
                          this.astCtxt.bvand(
                            op1,
                            this.astCtxt.bvnot(this.astCtxt.bv(mask, 128))
                          ),
                          temp
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PINSRW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmaxsd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Dword; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Dword);
                uint low = (dst.BitSize - BitSizes.Dword) - (index * BitSizes.Dword);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvsle(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.extract(high, low, op2),
                                this.astCtxt.extract(high, low, op1))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMAXSD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmaxsw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Word; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Word);
                uint low = (dst.BitSize - BitSizes.Word) - (index * BitSizes.Word);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvsle(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.extract(high, low, op2),
                                this.astCtxt.extract(high, low, op1))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMAXSW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmaxub_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Byte);
                uint low = (dst.BitSize - BitSizes.Byte) - (index * BitSizes.Byte);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvule(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.extract(high, low, op2),
                                this.astCtxt.extract(high, low, op1))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMAXUB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmaxud_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Dword; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Dword);
                uint low = (dst.BitSize - BitSizes.Dword) - (index * BitSizes.Dword);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvule(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.extract(high, low, op2),
                                this.astCtxt.extract(high, low, op1))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMAXUD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmaxuw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Word; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Word);
                uint low = (dst.BitSize - BitSizes.Word) - (index * BitSizes.Word);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvule(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.extract(high, low, op2),
                                this.astCtxt.extract(high, low, op1))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMAXUW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pminsb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Byte);
                uint low = (dst.BitSize - BitSizes.Byte) - (index * BitSizes.Byte);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvsge(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.extract(high, low, op2),
                                this.astCtxt.extract(high, low, op1))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMINSB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pminsd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Dword; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Dword);
                uint low = (dst.BitSize - BitSizes.Dword) - (index * BitSizes.Dword);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvsge(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.extract(high, low, op2),
                                this.astCtxt.extract(high, low, op1))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMINSD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pminsw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Word; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Word);
                uint low = (dst.BitSize - BitSizes.Word) - (index * BitSizes.Word);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvsge(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.extract(high, low, op2),
                                this.astCtxt.extract(high, low, op1))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMINSW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pminub_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Byte);
                uint low = (dst.BitSize - BitSizes.Byte) - (index * BitSizes.Byte);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvuge(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.extract(high, low, op2),
                                this.astCtxt.extract(high, low, op1))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMINUB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pminud_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Dword; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Dword);
                uint low = (dst.BitSize - BitSizes.Dword) - (index * BitSizes.Dword);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvuge(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.extract(high, low, op2),
                                this.astCtxt.extract(high, low, op1))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMINUD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pminuw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Word; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Word);
                uint low = (dst.BitSize - BitSizes.Word) - (index * BitSizes.Word);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvuge(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.extract(high, low, op2),
                                this.astCtxt.extract(high, low, op1))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMINUW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmovmskb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> mskb = new List<AbstractNode>();

            switch (src.Size)
            {
                case ByteSizes.Dqword:
                    mskb.Add(this.astCtxt.extract(127, 127, op2));
                    mskb.Add(this.astCtxt.extract(119, 119, op2));
                    mskb.Add(this.astCtxt.extract(111, 111, op2));
                    mskb.Add(this.astCtxt.extract(103, 103, op2));
                    mskb.Add(this.astCtxt.extract(95, 95, op2));
                    mskb.Add(this.astCtxt.extract(87, 87, op2));
                    mskb.Add(this.astCtxt.extract(79, 79, op2));
                    mskb.Add(this.astCtxt.extract(71, 71, op2));
                    goto case ByteSizes.Qword;

                case ByteSizes.Qword:
                    mskb.Add(this.astCtxt.extract(63, 63, op2));
                    mskb.Add(this.astCtxt.extract(55, 55, op2));
                    mskb.Add(this.astCtxt.extract(47, 47, op2));
                    mskb.Add(this.astCtxt.extract(39, 39, op2));
                    mskb.Add(this.astCtxt.extract(31, 31, op2));
                    mskb.Add(this.astCtxt.extract(23, 23, op2));
                    mskb.Add(this.astCtxt.extract(15, 15, op2));
                    mskb.Add(this.astCtxt.extract(7, 7, op2));
                    break;
            }

            var node = this.astCtxt.zx(
                          dst.BitSize - (uint)(mskb.Count()),
                          this.astCtxt.concat(mskb)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMOVMSKB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmovsxbd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            pck.Add(this.astCtxt.sx(BitSizes.Dword - BitSizes.Byte, this.astCtxt.extract(31, 24, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Dword - BitSizes.Byte, this.astCtxt.extract(23, 16, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Dword - BitSizes.Byte, this.astCtxt.extract(15, 8, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Dword - BitSizes.Byte, this.astCtxt.extract(7, 0, op2)));

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMOVSXBD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmovsxbq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            pck.Add(this.astCtxt.sx(BitSizes.Qword - BitSizes.Byte, this.astCtxt.extract(15, 8, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Qword - BitSizes.Byte, this.astCtxt.extract(7, 0, op2)));

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMOVSXBQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmovsxbw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            pck.Add(this.astCtxt.sx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(63, 56, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(55, 48, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(47, 40, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(39, 32, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(31, 24, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(23, 16, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(15, 8, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(7, 0, op2)));

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMOVSXBW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmovsxdq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            pck.Add(this.astCtxt.sx(BitSizes.Qword - BitSizes.Dword, this.astCtxt.extract(63, 32, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Qword - BitSizes.Dword, this.astCtxt.extract(31, 0, op2)));

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMOVSXDQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmovsxwd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            pck.Add(this.astCtxt.sx(BitSizes.Dword - BitSizes.Word, this.astCtxt.extract(63, 48, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Dword - BitSizes.Word, this.astCtxt.extract(47, 32, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Dword - BitSizes.Word, this.astCtxt.extract(31, 16, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Dword - BitSizes.Word, this.astCtxt.extract(15, 0, op2)));

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMOVSXWD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmovsxwq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            pck.Add(this.astCtxt.sx(BitSizes.Qword - BitSizes.Word, this.astCtxt.extract(31, 16, op2)));
            pck.Add(this.astCtxt.sx(BitSizes.Qword - BitSizes.Word, this.astCtxt.extract(15, 0, op2)));

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMOVSXWQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmovzxbd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            pck.Add(this.astCtxt.zx(BitSizes.Dword - BitSizes.Byte, this.astCtxt.extract(31, 24, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Dword - BitSizes.Byte, this.astCtxt.extract(23, 16, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Dword - BitSizes.Byte, this.astCtxt.extract(15, 8, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Dword - BitSizes.Byte, this.astCtxt.extract(7, 0, op2)));

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMOVZXBD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmovzxbq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            pck.Add(this.astCtxt.zx(BitSizes.Qword - BitSizes.Byte, this.astCtxt.extract(15, 8, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Qword - BitSizes.Byte, this.astCtxt.extract(7, 0, op2)));

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMOVZXBQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmovzxbw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            pck.Add(this.astCtxt.zx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(63, 56, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(55, 48, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(47, 40, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(39, 32, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(31, 24, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(23, 16, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(15, 8, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Word - BitSizes.Byte, this.astCtxt.extract(7, 0, op2)));

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMOVZXBW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmovzxdq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            pck.Add(this.astCtxt.zx(BitSizes.Qword - BitSizes.Dword, this.astCtxt.extract(63, 32, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Qword - BitSizes.Dword, this.astCtxt.extract(31, 0, op2)));

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMOVZXDQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmovzxwd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            pck.Add(this.astCtxt.zx(BitSizes.Dword - BitSizes.Word, this.astCtxt.extract(63, 48, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Dword - BitSizes.Word, this.astCtxt.extract(47, 32, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Dword - BitSizes.Word, this.astCtxt.extract(31, 16, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Dword - BitSizes.Word, this.astCtxt.extract(15, 0, op2)));

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMOVZXWD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pmovzxwq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            pck.Add(this.astCtxt.zx(BitSizes.Qword - BitSizes.Word, this.astCtxt.extract(31, 16, op2)));
            pck.Add(this.astCtxt.zx(BitSizes.Qword - BitSizes.Word, this.astCtxt.extract(15, 0, op2)));

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PMOVZXWQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pop_s(Instruction inst)
        {
          //  if (inst.Address == 0x00140029769)
              //  Debugger.Break();
            bool stackRelative = false;
            var stack = this.architecture.GetStackPointer();
            var stackValue = this.astBuilder.GetRegisterAst(stack);
            var dst = inst.Operands[0];
            var src = new OperandWrapper(new MemoryAccess() { Size = dst.Size, BaseRegister = stack });

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = op1;

            /*
             * Create the semantics - side effect
             *
             * Intel: If the ESP register is used as a base register for addressing a destination operand in
             * memory, the POP instruction computes the effective address of the operand after it increments
             * the ESP register.
             */
            if (dst.Type == OperandType.Mem)
            {
                Register baseReg = dst.MemoryAccess.BaseRegister;
                /* Check if the base register is the stack pointer */
                if (this.architecture.IsRegisterValid(baseReg) && this.architecture.GetParentRegister(baseReg) == stack)
                {
                    /* Align the stack */
                    alignAddStack_s(inst, src.Size);
                    /* Re-initialize the memory access */
                    this.astBuilder.InitLeaAst(dst.MemoryAccess);
                    stackRelative = true;
                }
            }

            /*
             * Create the semantics - side effect
             *
             * Don't increment SP if the destination register is SP.
             */
            else if (dst.Type == OperandType.Reg)
            {
                if (this.architecture.GetParentRegister(dst.Register) == stack)
                {
                    stackRelative = true;
                }
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "POP operation");


            /* Create the semantics - side effect */
            if (!stackRelative)
                alignAddStack_s(inst, src.Size);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void popal_s(Instruction inst)
        {
            var stack = this.architecture.GetStackPointer();
            var stackValue = this.astBuilder.GetRegisterAst(stack);
            var dst1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EDI));
            var dst2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ESI));
            var dst3 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EBP));
            var dst4 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EBX));
            var dst5 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EDX));
            var dst6 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ECX));
            var dst7 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EAX));
            ((Action)(() => { }))();
            ((Action)(() => { }))();
            ((Action)(() => { }))();
            /* stack.Size * 3 (ESP) is voluntarily omitted */
            ((Action)(() => { }))();
            ((Action)(() => { }))();
            ((Action)(() => { }))();
            ((Action)(() => { }))();

            /* Create symbolic operands and semantics */
            var node1 = new MemoryNode(astCtxt.bvadd(stackValue, astCtxt.bv(stack.Size * 0, stack.BitSize)), stack.BitSize);
            var node2 = new MemoryNode(astCtxt.bvadd(stackValue, astCtxt.bv(stack.Size * 1, stack.BitSize)), stack.BitSize);
            var node3 = new MemoryNode(astCtxt.bvadd(stackValue, astCtxt.bv(stack.Size * 2, stack.BitSize)), stack.BitSize);
            var node4 = new MemoryNode(astCtxt.bvadd(stackValue, astCtxt.bv(stack.Size * 4, stack.BitSize)), stack.BitSize);
            var node5 = new MemoryNode(astCtxt.bvadd(stackValue, astCtxt.bv(stack.Size * 5, stack.BitSize)), stack.BitSize);
            var node6 = new MemoryNode(astCtxt.bvadd(stackValue, astCtxt.bv(stack.Size * 6, stack.BitSize)), stack.BitSize);
            var node7 = new MemoryNode(astCtxt.bvadd(stackValue, astCtxt.bv(stack.Size * 7, stack.BitSize)), stack.BitSize);

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst1, "POPAL EDI operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst2, "POPAL ESI operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, dst3, "POPAL EBP operation");
            var expr4 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node4, dst4, "POPAL EBX operation");
            var expr5 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node5, dst5, "POPAL EDX operation");
            var expr6 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node6, dst6, "POPAL ECX operation");
            var expr7 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node7, dst7, "POPAL EAX operation");


            /* Create the semantics - side effect */
            alignAddStack_s(inst, stack.Size * 8);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void popf_s(Instruction inst)
        {
            var stack = this.architecture.GetStackPointer();
            var stackValue = this.astBuilder.GetRegisterAst(stack);
            var dst1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var dst2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            var dst3 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            var dst4 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));
            var dst5 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var dst6 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_TF));
            var dst7 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_IF));
            var dst8 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));
            var dst9 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var dst10 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_NT));
            var src = new OperandWrapper(new MemoryAccess() { Size = stack.Size, BaseRegister = stack });

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node1 = this.astCtxt.extract(0, 0, op1);
            var node2 = this.astCtxt.extract(2, 2, op1);
            var node3 = this.astCtxt.extract(4, 4, op1);
            var node4 = this.astCtxt.extract(6, 6, op1);
            var node5 = this.astCtxt.extract(7, 7, op1);
            var node6 = this.astCtxt.extract(8, 8, op1);
            var node7 = this.astCtxt.bvtrue(); /* IF true? */
            var node8 = this.astCtxt.extract(10, 10, op1);
            var node9 = this.astCtxt.extract(11, 11, op1);
            /* IOPL don't support */
            var node10 = this.astCtxt.extract(14, 14, op1);

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst1.Register, "POPF CF operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst2.Register, "POPF PF operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, dst3.Register, "POPF AF operation");
            var expr4 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node4, dst4.Register, "POPF ZF operation");
            var expr5 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node5, dst5.Register, "POPF SF operation");
            var expr6 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node6, dst6.Register, "POPF TF operation");
            var expr7 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node7, dst7.Register, "POPF IF operation");
            var expr8 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node8, dst8.Register, "POPF DF operation");
            var expr9 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node9, dst9.Register, "POPF OF operation");
            var expr10 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node10, dst10.Register, "POPF NT operation");


            /* Create the semantics - side effect */
            alignAddStack_s(inst, src.Size);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void popfd_s(Instruction inst)
        {
            var stack = this.architecture.GetStackPointer();
            var stackValue = this.astBuilder.GetRegisterAst(stack);
            var dst1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var dst2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            var dst3 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            var dst4 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));
            var dst5 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var dst6 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_TF));
            var dst7 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_IF));
            var dst8 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));
            var dst9 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var dst10 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_NT));
            var dst11 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RF));
            var dst12 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AC));
            var dst13 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ID));
            var src = new OperandWrapper(new MemoryAccess() { Size = stack.Size, BaseRegister = stack });

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node1 = this.astCtxt.extract(0, 0, op1);
            var node2 = this.astCtxt.extract(2, 2, op1);
            var node3 = this.astCtxt.extract(4, 4, op1);
            var node4 = this.astCtxt.extract(6, 6, op1);
            var node5 = this.astCtxt.extract(7, 7, op1);
            var node6 = this.astCtxt.extract(8, 8, op1);
            var node7 = this.astCtxt.bvtrue(); /* IF true? */
            var node8 = this.astCtxt.extract(10, 10, op1);
            var node9 = this.astCtxt.extract(11, 11, op1);
            /* IOPL don't support */
            var node10 = this.astCtxt.extract(14, 14, op1);
            var node11 = this.astCtxt.bvfalse(); /* RF clear */
            /* VM not changed */
            var node12 = this.astCtxt.extract(18, 18, op1);
            /* VIP not changed */
            /* VIF not changed */
            var node13 = this.astCtxt.extract(21, 21, op1);

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst1.Register, "POPFD CF operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst2.Register, "POPFD PF operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, dst3.Register, "POPFD AF operation");
            var expr4 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node4, dst4.Register, "POPFD ZF operation");
            var expr5 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node5, dst5.Register, "POPFD SF operation");
            var expr6 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node6, dst6.Register, "POPFD TF operation");
            var expr7 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node7, dst7.Register, "POPFD IF operation");
            var expr8 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node8, dst8.Register, "POPFD DF operation");
            var expr9 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node9, dst9.Register, "POPFD OF operation");
            var expr10 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node10, dst10.Register, "POPFD NT operation");
            var expr11 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node11, dst11.Register, "POPFD RF operation");
            var expr12 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node12, dst12.Register, "POPFD AC operation");
            var expr13 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node13, dst13.Register, "POPFD ID operation");


            /* Create the semantics - side effect */
            alignAddStack_s(inst, src.Size);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void popfq_s(Instruction inst)
        {
            var stack = this.architecture.GetStackPointer();
            var stackValue = this.astBuilder.GetRegisterAst(stack);
            var dst1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var dst2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            var dst3 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            var dst4 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));
            var dst5 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var dst6 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_TF));
            var dst7 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_IF));
            var dst8 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));
            var dst9 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var dst10 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_NT));
            var dst11 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_RF));
            var dst12 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AC));
            var dst13 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ID));
            var src = new OperandWrapper(new MemoryAccess() { Size = stack.Size, BaseRegister = stack });

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node1 = this.astCtxt.extract(0, 0, op1);
            var node2 = this.astCtxt.extract(2, 2, op1);
            var node3 = this.astCtxt.extract(4, 4, op1);
            var node4 = this.astCtxt.extract(6, 6, op1);
            var node5 = this.astCtxt.extract(7, 7, op1);
            var node6 = this.astCtxt.extract(8, 8, op1);
            var node7 = this.astCtxt.bvtrue(); /* IF true? */
            var node8 = this.astCtxt.extract(10, 10, op1);
            var node9 = this.astCtxt.extract(11, 11, op1);
            /* IOPL don't support */
            var node10 = this.astCtxt.extract(14, 14, op1);
            var node11 = this.astCtxt.bvfalse(); /* RF clear */
            /* VM not changed */
            var node12 = this.astCtxt.extract(18, 18, op1);
            /* VIP not changed */
            /* VIF not changed */
            var node13 = this.astCtxt.extract(21, 21, op1);

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst1.Register, "POPFQ CF operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst2.Register, "POPFQ PF operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, dst3.Register, "POPFQ AF operation");
            var expr4 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node4, dst4.Register, "POPFQ ZF operation");
            var expr5 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node5, dst5.Register, "POPFQ SF operation");
            var expr6 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node6, dst6.Register, "POPFQ TF operation");
            var expr7 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node7, dst7.Register, "POPFQ IF operation");
            var expr8 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node8, dst8.Register, "POPFQ DF operation");
            var expr9 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node9, dst9.Register, "POPFQ OF operation");
            var expr10 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node10, dst10.Register, "POPFD NT operation");
            var expr11 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node11, dst11.Register, "POPFD RF operation");
            var expr12 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node12, dst12.Register, "POPFD AC operation");
            var expr13 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node13, dst13.Register, "POPFD ID operation");


            /* Create the semantics - side effect */
            alignAddStack_s(inst, src.Size);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void por_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvor(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "POR operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void prefetchx_s(Instruction inst)
        {
            var src = inst.Operands[0];

            /* Only specify that the instruction performs an implicit memory read */
            this.astBuilder.GetOperandAst(inst, src);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pshufd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var ord = inst.Operands[2];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, ord);

            /* Create the semantics */
            List<AbstractNode> pack = new List<AbstractNode>();

            pack.Add(
              this.astCtxt.extract(31, 0,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Dqword - 2, this.astCtxt.extract(7, 6, op3)),
                    this.astCtxt.bv(32, BitSizes.Dqword)
                  )
                )
              )
            );
            pack.Add(
              this.astCtxt.extract(31, 0,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Dqword - 2, this.astCtxt.extract(5, 4, op3)),
                    this.astCtxt.bv(32, BitSizes.Dqword)
                  )
                )
              )
            );
            pack.Add(
              this.astCtxt.extract(31, 0,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Dqword - 2, this.astCtxt.extract(3, 2, op3)),
                    this.astCtxt.bv(32, BitSizes.Dqword)
                  )
                )
              )
            );
            pack.Add(
              this.astCtxt.extract(31, 0,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Dqword - 2, this.astCtxt.extract(1, 0, op3)),
                    this.astCtxt.bv(32, BitSizes.Dqword)
                  )
                )
              )
            );

            var node = this.astCtxt.concat(pack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PSHUFD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pshufhw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var ord = inst.Operands[2];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, ord);

            /* Create the semantics */
            List<AbstractNode> pack = new List<AbstractNode>();

            pack.Add(
              this.astCtxt.extract(79, 64,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Dqword - 2, this.astCtxt.extract(7, 6, op3)),
                    this.astCtxt.bv(16, BitSizes.Dqword)
                  )
                )
              )
            );
            pack.Add(
              this.astCtxt.extract(79, 64,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Dqword - 2, this.astCtxt.extract(5, 4, op3)),
                    this.astCtxt.bv(16, BitSizes.Dqword)
                  )
                )
              )
            );
            pack.Add(
              this.astCtxt.extract(79, 64,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Dqword - 2, this.astCtxt.extract(3, 2, op3)),
                    this.astCtxt.bv(16, BitSizes.Dqword)
                  )
                )
              )
            );
            pack.Add(
              this.astCtxt.extract(79, 64,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Dqword - 2, this.astCtxt.extract(1, 0, op3)),
                    this.astCtxt.bv(16, BitSizes.Dqword)
                  )
                )
              )
            );
            pack.Add(
              this.astCtxt.extract(63, 0, op2)
            );

            var node = this.astCtxt.concat(pack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PSHUFHW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pshuflw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var ord = inst.Operands[2];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, ord);

            /* Create the semantics */
            List<AbstractNode> pack = new List<AbstractNode>();

            pack.Add(
              this.astCtxt.extract(127, 64, op2)
            );
            pack.Add(
              this.astCtxt.extract(15, 0,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Dqword - 2, this.astCtxt.extract(7, 6, op3)),
                    this.astCtxt.bv(16, BitSizes.Dqword)
                  )
                )
              )
            );
            pack.Add(
              this.astCtxt.extract(15, 0,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Dqword - 2, this.astCtxt.extract(5, 4, op3)),
                    this.astCtxt.bv(16, BitSizes.Dqword)
                  )
                )
              )
            );
            pack.Add(
              this.astCtxt.extract(15, 0,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Dqword - 2, this.astCtxt.extract(3, 2, op3)),
                    this.astCtxt.bv(16, BitSizes.Dqword)
                  )
                )
              )
            );
            pack.Add(
              this.astCtxt.extract(15, 0,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Dqword - 2, this.astCtxt.extract(1, 0, op3)),
                    this.astCtxt.bv(16, BitSizes.Dqword)
                  )
                )
              )
            );

            var node = this.astCtxt.concat(pack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PSHUFLW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pshufw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var ord = inst.Operands[2];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, ord);

            /* Create the semantics */
            List<AbstractNode> pack = new List<AbstractNode>();

            pack.Add(
              this.astCtxt.extract(15, 0,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Qword - 2, this.astCtxt.extract(7, 6, op3)),
                    this.astCtxt.bv(16, BitSizes.Qword)
                  )
                )
              )
            );
            pack.Add(
              this.astCtxt.extract(15, 0,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Qword - 2, this.astCtxt.extract(5, 4, op3)),
                    this.astCtxt.bv(16, BitSizes.Qword)
                  )
                )
              )
            );
            pack.Add(
              this.astCtxt.extract(15, 0,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Qword - 2, this.astCtxt.extract(3, 2, op3)),
                    this.astCtxt.bv(16, BitSizes.Qword)
                  )
                )
              )
            );
            pack.Add(
              this.astCtxt.extract(15, 0,
                this.astCtxt.bvlshr(
                  op2,
                  this.astCtxt.bvmul(
                    this.astCtxt.zx(BitSizes.Qword - 2, this.astCtxt.extract(1, 0, op3)),
                    this.astCtxt.bv(16, BitSizes.Qword)
                  )
                )
              )
            );

            var node = this.astCtxt.concat(pack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PSHUFW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pslld_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astCtxt.zx(dst.BitSize - src.BitSize, this.astBuilder.GetOperandAst(inst, src));

            /* Create the semantics */
            List<AbstractNode> packed = new List<AbstractNode>();

            switch (dst.BitSize)
            {
                /* XMM */
                case BitSizes.Dqword:
                    packed.Add(this.astCtxt.bvshl(this.astCtxt.extract(127, 96, op1), this.astCtxt.extract(31, 0, op2)));
                    packed.Add(this.astCtxt.bvshl(this.astCtxt.extract(95, 64, op1), this.astCtxt.extract(31, 0, op2)));
                    goto case BitSizes.Qword;

                /* MMX */
                case BitSizes.Qword:
                    packed.Add(this.astCtxt.bvshl(this.astCtxt.extract(63, 32, op1), this.astCtxt.extract(31, 0, op2)));
                    packed.Add(this.astCtxt.bvshl(this.astCtxt.extract(31, 0, op1), this.astCtxt.extract(31, 0, op2)));
                    break;

                default:
                    throw new Exception("pslld_s(): Invalid operand size.");
            }

            var node = this.astCtxt.concat(packed);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PSLLD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pslldq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astCtxt.zx(dst.BitSize - src.BitSize, this.astBuilder.GetOperandAst(inst, src));

            /* Create the semantics */
            var node = this.astCtxt.bvshl(
                          op1,
                          this.astCtxt.bvmul(
                            this.astCtxt.ite(
                              this.astCtxt.bvuge(op2, this.astCtxt.bv(BitSizes.Word, dst.BitSize)),
                              this.astCtxt.bv(BitSizes.Word, dst.BitSize),
                              op2
                            ),
                            this.astCtxt.bv(ByteSizes.Qword, dst.BitSize)
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PSLLDQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void psllq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astCtxt.zx(dst.BitSize - src.BitSize, this.astBuilder.GetOperandAst(inst, src));

            /* Create the semantics */
            AbstractNode node;

            List<AbstractNode> packed = new List<AbstractNode>();

            switch (dst.BitSize)
            {
                /* XMM */
                case BitSizes.Dqword:
                    packed.Add(this.astCtxt.bvshl(this.astCtxt.extract(127, 64, op1), this.astCtxt.extract(63, 0, op2)));
                    packed.Add(this.astCtxt.bvshl(this.astCtxt.extract(63, 0, op1), this.astCtxt.extract(63, 0, op2)));
                    node = this.astCtxt.concat(packed);
                    break;

                /* MMX */
                case BitSizes.Qword:
                    /* MMX register is only one QWORD so it's a simple shl */
                    node = this.astCtxt.bvshl(op1, op2);
                    break;

                default:
                    throw new Exception("psllq_s(): Invalid operand size.");
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PSLLQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void psllw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astCtxt.zx(dst.BitSize - src.BitSize, this.astBuilder.GetOperandAst(inst, src));

            /* Create the semantics */
            List<AbstractNode> packed = new List<AbstractNode>();

            switch (dst.BitSize)
            {
                /* XMM */
                case BitSizes.Dqword:
                    packed.Add(this.astCtxt.bvshl(this.astCtxt.extract(127, 112, op1), this.astCtxt.extract(15, 0, op2)));
                    packed.Add(this.astCtxt.bvshl(this.astCtxt.extract(111, 96, op1), this.astCtxt.extract(15, 0, op2)));
                    packed.Add(this.astCtxt.bvshl(this.astCtxt.extract(95, 80, op1), this.astCtxt.extract(15, 0, op2)));
                    packed.Add(this.astCtxt.bvshl(this.astCtxt.extract(79, 64, op1), this.astCtxt.extract(15, 0, op2)));
                    goto case BitSizes.Qword;

                /* MMX */
                case BitSizes.Qword:
                    packed.Add(this.astCtxt.bvshl(this.astCtxt.extract(63, 48, op1), this.astCtxt.extract(15, 0, op2)));
                    packed.Add(this.astCtxt.bvshl(this.astCtxt.extract(47, 32, op1), this.astCtxt.extract(15, 0, op2)));
                    packed.Add(this.astCtxt.bvshl(this.astCtxt.extract(31, 16, op1), this.astCtxt.extract(15, 0, op2)));
                    packed.Add(this.astCtxt.bvshl(this.astCtxt.extract(15, 0, op1), this.astCtxt.extract(15, 0, op2)));
                    break;

                default:
                    throw new Exception("psllw_s(): Invalid operand size.");
            }

            var node = this.astCtxt.concat(packed);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PSLLW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void psrldq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astCtxt.zx(dst.BitSize - src.BitSize, this.astBuilder.GetOperandAst(inst, src));

            /* Create the semantics */
            var node = this.astCtxt.bvlshr(
                          op1,
                          this.astCtxt.bvmul(
                            this.astCtxt.ite(
                              this.astCtxt.bvuge(op2, this.astCtxt.bv(BitSizes.Word, dst.BitSize)),
                              this.astCtxt.bv(BitSizes.Word, dst.BitSize),
                              op2
                            ),
                            this.astCtxt.bv(ByteSizes.Qword, dst.BitSize)
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PSRLDQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void psubb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> packed = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* XMM */
                case BitSizes.Dqword:
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(127, 120, op1), this.astCtxt.extract(127, 120, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(119, 112, op1), this.astCtxt.extract(119, 112, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(111, 104, op1), this.astCtxt.extract(111, 104, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(103, 96, op1), this.astCtxt.extract(103, 96, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(95, 88, op1), this.astCtxt.extract(95, 88, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(87, 80, op1), this.astCtxt.extract(87, 80, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(79, 72, op1), this.astCtxt.extract(79, 72, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(71, 64, op1), this.astCtxt.extract(71, 64, op2)));
                    goto case BitSizes.Qword;

                /* MMX */
                case BitSizes.Qword:
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(63, 56, op1), this.astCtxt.extract(63, 56, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(55, 48, op1), this.astCtxt.extract(55, 48, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(47, 40, op1), this.astCtxt.extract(47, 40, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(39, 32, op1), this.astCtxt.extract(39, 32, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(31, 24, op1), this.astCtxt.extract(31, 24, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(23, 16, op1), this.astCtxt.extract(23, 16, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(15, 8, op1), this.astCtxt.extract(15, 8, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(7, 0, op1), this.astCtxt.extract(7, 0, op2)));
                    break;

                default:
                    throw new Exception("psubb_s(): Invalid operand size.");

            }

            var node = this.astCtxt.concat(packed);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PSUBB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void psubd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> packed = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* XMM */
                case BitSizes.Dqword:
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(127, 96, op1), this.astCtxt.extract(127, 96, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(95, 64, op1), this.astCtxt.extract(95, 64, op2)));
                    goto case BitSizes.Qword;

                /* MMX */
                case BitSizes.Qword:
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(63, 32, op1), this.astCtxt.extract(63, 32, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(31, 0, op1), this.astCtxt.extract(31, 0, op2)));
                    break;

                default:
                    throw new Exception("psubd_s(): Invalid operand size.");

            }

            var node = this.astCtxt.concat(packed);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PSUBD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void psubq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> packed = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* XMM */
                case BitSizes.Dqword:
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(127, 64, op1), this.astCtxt.extract(127, 64, op2)));
                    goto case BitSizes.Qword;

                /* MMX */
                case BitSizes.Qword:
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(63, 0, op1), this.astCtxt.extract(63, 0, op2)));
                    break;

                default:
                    throw new Exception("psubq_s(): Invalid operand size.");

            }

            var node = this.astCtxt.concat(packed);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PSUBQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void psubw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> packed = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* XMM */
                case BitSizes.Dqword:
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(127, 112, op1), this.astCtxt.extract(127, 112, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(111, 96, op1), this.astCtxt.extract(111, 96, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(95, 80, op1), this.astCtxt.extract(95, 80, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(79, 64, op1), this.astCtxt.extract(79, 64, op2)));
                    goto case BitSizes.Qword;

                /* MMX */
                case BitSizes.Qword:
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(63, 48, op1), this.astCtxt.extract(63, 48, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(47, 32, op1), this.astCtxt.extract(47, 32, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(31, 16, op1), this.astCtxt.extract(31, 16, op2)));
                    packed.Add(this.astCtxt.bvsub(this.astCtxt.extract(15, 0, op1), this.astCtxt.extract(15, 0, op2)));
                    break;

                default:
                    throw new Exception("psubw_s(): Invalid operand size.");

            }

            var node = this.astCtxt.concat(packed);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PSUBW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void ptest_s(Instruction inst)
        {
            var src1 = inst.Operands[0];
            var src2 = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            var node1 = this.astCtxt.bvand(op1, op2);
            var node2 = this.astCtxt.bvand(op1, this.astCtxt.bvnot(op2));

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "PTEST operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node2, "PTEST operation");


            /* Update symbolic flags */
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF), "Clears adjust flag");
            this.cfPtest_s(inst, expr2, src1, true);
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Clears overflow flag");
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF), "Clears parity flag");
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF), "Clears sign flag");
            this.zf_s(inst, expr1, src1, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void punpckhbw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> unpack = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* MMX */
                case BitSizes.Qword:
                    unpack.Add(this.astCtxt.extract(63, 56, op2));
                    unpack.Add(this.astCtxt.extract(63, 56, op1));
                    unpack.Add(this.astCtxt.extract(55, 48, op2));
                    unpack.Add(this.astCtxt.extract(55, 48, op1));
                    unpack.Add(this.astCtxt.extract(47, 40, op2));
                    unpack.Add(this.astCtxt.extract(55, 40, op1));
                    unpack.Add(this.astCtxt.extract(39, 32, op2));
                    unpack.Add(this.astCtxt.extract(39, 32, op1));
                    break;

                /* XMM */
                case BitSizes.Dqword:
                    unpack.Add(this.astCtxt.extract(127, 120, op2));
                    unpack.Add(this.astCtxt.extract(127, 120, op1));
                    unpack.Add(this.astCtxt.extract(119, 112, op2));
                    unpack.Add(this.astCtxt.extract(119, 112, op1));
                    unpack.Add(this.astCtxt.extract(111, 104, op2));
                    unpack.Add(this.astCtxt.extract(111, 104, op1));
                    unpack.Add(this.astCtxt.extract(103, 96, op2));
                    unpack.Add(this.astCtxt.extract(103, 96, op1));
                    unpack.Add(this.astCtxt.extract(95, 88, op2));
                    unpack.Add(this.astCtxt.extract(95, 88, op1));
                    unpack.Add(this.astCtxt.extract(87, 80, op2));
                    unpack.Add(this.astCtxt.extract(87, 80, op1));
                    unpack.Add(this.astCtxt.extract(79, 72, op2));
                    unpack.Add(this.astCtxt.extract(79, 72, op1));
                    unpack.Add(this.astCtxt.extract(71, 64, op2));
                    unpack.Add(this.astCtxt.extract(71, 64, op1));
                    break;

                default:
                    throw new Exception("punpckhbw_s(): Invalid operand size.");
            }

            var node = this.astCtxt.concat(unpack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PUNPCKHBW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void punpckhdq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> unpack = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* MMX */
                case BitSizes.Qword:
                    unpack.Add(this.astCtxt.extract(63, 32, op2));
                    unpack.Add(this.astCtxt.extract(63, 32, op1));
                    break;

                /* XMM */
                case BitSizes.Dqword:
                    unpack.Add(this.astCtxt.extract(127, 96, op2));
                    unpack.Add(this.astCtxt.extract(127, 96, op1));
                    unpack.Add(this.astCtxt.extract(95, 64, op2));
                    unpack.Add(this.astCtxt.extract(95, 64, op1));
                    break;

                default:
                    throw new Exception("punpckhdq_s(): Invalid operand size.");
            }

            var node = this.astCtxt.concat(unpack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PUNPCKHDQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void punpckhqdq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> unpack = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* XMM */
                case BitSizes.Dqword:
                    unpack.Add(this.astCtxt.extract(127, 64, op2));
                    unpack.Add(this.astCtxt.extract(127, 64, op1));
                    break;

                default:
                    throw new Exception("punpckhqdq_s(): Invalid operand size.");
            }

            var node = this.astCtxt.concat(unpack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PUNPCKHQDQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void punpckhwd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> unpack = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* MMX */
                case BitSizes.Qword:
                    unpack.Add(this.astCtxt.extract(63, 48, op2));
                    unpack.Add(this.astCtxt.extract(63, 48, op1));
                    unpack.Add(this.astCtxt.extract(47, 32, op2));
                    unpack.Add(this.astCtxt.extract(47, 32, op1));
                    break;

                /* XMM */
                case BitSizes.Dqword:
                    unpack.Add(this.astCtxt.extract(127, 112, op2));
                    unpack.Add(this.astCtxt.extract(127, 112, op1));
                    unpack.Add(this.astCtxt.extract(111, 96, op2));
                    unpack.Add(this.astCtxt.extract(111, 96, op1));
                    unpack.Add(this.astCtxt.extract(95, 80, op2));
                    unpack.Add(this.astCtxt.extract(95, 80, op1));
                    unpack.Add(this.astCtxt.extract(79, 64, op2));
                    unpack.Add(this.astCtxt.extract(79, 64, op1));
                    break;

                default:
                    throw new Exception("punpckhwd_s(): Invalid operand size.");
            }

            var node = this.astCtxt.concat(unpack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PUNPCKHWD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void punpcklbw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> unpack = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* MMX */
                case BitSizes.Qword:
                    unpack.Add(this.astCtxt.extract(31, 24, op2));
                    unpack.Add(this.astCtxt.extract(31, 24, op1));
                    unpack.Add(this.astCtxt.extract(23, 16, op2));
                    unpack.Add(this.astCtxt.extract(23, 16, op1));
                    unpack.Add(this.astCtxt.extract(15, 8, op2));
                    unpack.Add(this.astCtxt.extract(15, 8, op1));
                    unpack.Add(this.astCtxt.extract(7, 0, op2));
                    unpack.Add(this.astCtxt.extract(7, 0, op1));
                    break;

                /* XMM */
                case BitSizes.Dqword:
                    unpack.Add(this.astCtxt.extract(63, 56, op2));
                    unpack.Add(this.astCtxt.extract(63, 56, op1));
                    unpack.Add(this.astCtxt.extract(55, 48, op2));
                    unpack.Add(this.astCtxt.extract(55, 48, op1));
                    unpack.Add(this.astCtxt.extract(47, 40, op2));
                    unpack.Add(this.astCtxt.extract(47, 40, op1));
                    unpack.Add(this.astCtxt.extract(39, 32, op2));
                    unpack.Add(this.astCtxt.extract(39, 32, op1));
                    unpack.Add(this.astCtxt.extract(31, 24, op2));
                    unpack.Add(this.astCtxt.extract(31, 24, op1));
                    unpack.Add(this.astCtxt.extract(23, 16, op2));
                    unpack.Add(this.astCtxt.extract(23, 16, op1));
                    unpack.Add(this.astCtxt.extract(15, 8, op2));
                    unpack.Add(this.astCtxt.extract(15, 8, op1));
                    unpack.Add(this.astCtxt.extract(7, 0, op2));
                    unpack.Add(this.astCtxt.extract(7, 0, op1));
                    break;

                default:
                    throw new Exception("punpcklbw_s(): Invalid operand size.");
            }

            var node = this.astCtxt.concat(unpack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PUNPCKLBW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void punpckldq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> unpack = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* MMX */
                case BitSizes.Qword:
                    unpack.Add(this.astCtxt.extract(31, 0, op2));
                    unpack.Add(this.astCtxt.extract(31, 0, op1));
                    break;

                /* XMM */
                case BitSizes.Dqword:
                    unpack.Add(this.astCtxt.extract(63, 32, op2));
                    unpack.Add(this.astCtxt.extract(63, 32, op1));
                    unpack.Add(this.astCtxt.extract(31, 0, op2));
                    unpack.Add(this.astCtxt.extract(31, 0, op1));
                    break;

                default:
                    throw new Exception("punpckldq_s(): Invalid operand size.");
            }

            var node = this.astCtxt.concat(unpack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PUNPCKLDQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void punpcklqdq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> unpack = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* XMM */
                case BitSizes.Dqword:
                    unpack.Add(this.astCtxt.extract(63, 0, op2));
                    unpack.Add(this.astCtxt.extract(63, 0, op1));
                    break;

                default:
                    throw new Exception("punpcklqdq_s(): Invalid operand size.");
            }

            var node = this.astCtxt.concat(unpack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PUNPCKLQDQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void punpcklwd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> unpack = new List<AbstractNode>();

            switch (dst.BitSize)
            {

                /* MMX */
                case BitSizes.Qword:
                    unpack.Add(this.astCtxt.extract(31, 16, op2));
                    unpack.Add(this.astCtxt.extract(31, 16, op1));
                    unpack.Add(this.astCtxt.extract(15, 0, op2));
                    unpack.Add(this.astCtxt.extract(15, 0, op1));
                    break;

                /* XMM */
                case BitSizes.Dqword:
                    unpack.Add(this.astCtxt.extract(63, 48, op2));
                    unpack.Add(this.astCtxt.extract(63, 48, op1));
                    unpack.Add(this.astCtxt.extract(47, 32, op2));
                    unpack.Add(this.astCtxt.extract(47, 32, op1));
                    unpack.Add(this.astCtxt.extract(31, 16, op2));
                    unpack.Add(this.astCtxt.extract(31, 16, op1));
                    unpack.Add(this.astCtxt.extract(15, 0, op2));
                    unpack.Add(this.astCtxt.extract(15, 0, op1));
                    break;

                default:
                    throw new Exception("punpcklwd_s(): Invalid operand size.");
            }

            var node = this.astCtxt.concat(unpack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PUNPCKLWD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void push_s(Instruction inst)
        {
            var src = inst.Operands[0];
            var stack = this.architecture.GetStackPointer();
            uint size = stack.Size;

            /* If it's an immediate source, the memory access is always based on the arch size */
            if (src.Type != OperandType.Imm)
                size = src.Size;

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics - side effect */
            var stackValue = alignSubStack_s(inst, size);
            var dst = new MemoryNode(stackValue, stack.BitSize);

            /* Create the semantics */
            var node = this.astCtxt.zx(dst.BitSize - src.BitSize, op1);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PUSH operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pushal_s(Instruction inst)
        {
            var stack = this.architecture.GetStackPointer();
            var stackValue = this.astBuilder.GetRegisterAst(stack);
            var dst1 = new MemoryNode(astCtxt.bvsub(stackValue, astCtxt.bv(stack.Size * 1, stack.BitSize)), stack.BitSize);
            var dst2 = new MemoryNode(astCtxt.bvsub(stackValue, astCtxt.bv(stack.Size * 2, stack.BitSize)), stack.BitSize);
            var dst3 = new MemoryNode(astCtxt.bvsub(stackValue, astCtxt.bv(stack.Size * 3, stack.BitSize)), stack.BitSize);
            var dst4 = new MemoryNode(astCtxt.bvsub(stackValue, astCtxt.bv(stack.Size * 4, stack.BitSize)), stack.BitSize);
            var dst5 = new MemoryNode(astCtxt.bvsub(stackValue, astCtxt.bv(stack.Size * 5, stack.BitSize)), stack.BitSize);
            var dst6 = new MemoryNode(astCtxt.bvsub(stackValue, astCtxt.bv(stack.Size * 6, stack.BitSize)), stack.BitSize);
            var dst7 = new MemoryNode(astCtxt.bvsub(stackValue, astCtxt.bv(stack.Size * 7, stack.BitSize)), stack.BitSize);
            var dst8 = new MemoryNode(astCtxt.bvsub(stackValue, astCtxt.bv(stack.Size * 8, stack.BitSize)), stack.BitSize);
            var src1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EAX));
            var src2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ECX));
            var src3 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EDX));
            var src4 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EBX));
            var src5 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ESP));
            var src6 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EBP));
            var src7 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ESI));
            var src8 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EDI));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);
            var op3 = this.astBuilder.GetOperandAst(inst, src3);
            var op4 = this.astBuilder.GetOperandAst(inst, src4);
            var op5 = this.astBuilder.GetOperandAst(inst, src5);
            var op6 = this.astBuilder.GetOperandAst(inst, src6);
            var op7 = this.astBuilder.GetOperandAst(inst, src7);
            var op8 = this.astBuilder.GetOperandAst(inst, src8);

            /* Create the semantics */
            var node1 = this.astCtxt.zx(dst1.BitSize - src1.BitSize, op1);
            var node2 = this.astCtxt.zx(dst2.BitSize - src2.BitSize, op2);
            var node3 = this.astCtxt.zx(dst3.BitSize - src3.BitSize, op3);
            var node4 = this.astCtxt.zx(dst4.BitSize - src4.BitSize, op4);
            var node5 = this.astCtxt.zx(dst5.BitSize - src5.BitSize, op5);
            var node6 = this.astCtxt.zx(dst6.BitSize - src6.BitSize, op6);
            var node7 = this.astCtxt.zx(dst7.BitSize - src7.BitSize, op7);
            var node8 = this.astCtxt.zx(dst8.BitSize - src8.BitSize, op8);

            /* Create symbolic expression */
            alignSubStack_s(inst, 32);
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst1, "PUSHAL EAX operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst2, "PUSHAL ECX operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, dst3, "PUSHAL EDX operation");
            var expr4 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node4, dst4, "PUSHAL EBX operation");
            var expr5 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node5, dst5, "PUSHAL ESP operation");
            var expr6 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node6, dst6, "PUSHAL EBP operation");
            var expr7 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node7, dst7, "PUSHAL ESI operation");
            var expr8 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node8, dst8, "PUSHAL EDI operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pushfd_s(Instruction inst)
        {
            var stack = this.architecture.GetStackPointer();

            /* Create the semantics - side effect */
            var stackValue = alignSubStack_s(inst, stack.Size);
            var dst = new MemoryNode(stackValue, stack.BitSize);
            var src1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var src2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            var src3 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            var src4 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));
            var src5 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var src6 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_TF));
            var src7 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_IF));
            var src8 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));
            var src9 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var src10 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_NT));
            var src11 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AC));
            var src12 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_VIF));
            var src13 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_VIP));
            var src14 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ID));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);
            var op3 = this.astBuilder.GetOperandAst(inst, src3);
            var op4 = this.astBuilder.GetOperandAst(inst, src4);
            var op5 = this.astBuilder.GetOperandAst(inst, src5);
            var op6 = this.astBuilder.GetOperandAst(inst, src6);
            var op7 = this.astBuilder.GetOperandAst(inst, src7);
            var op8 = this.astBuilder.GetOperandAst(inst, src8);
            var op9 = this.astBuilder.GetOperandAst(inst, src9);
            var op10 = this.astBuilder.GetOperandAst(inst, src10);
            var op11 = this.astBuilder.GetOperandAst(inst, src11);
            var op12 = this.astBuilder.GetOperandAst(inst, src12);
            var op13 = this.astBuilder.GetOperandAst(inst, src13);
            var op14 = this.astBuilder.GetOperandAst(inst, src14);

            /* Create the semantics */
            List<AbstractNode> eflags = new List<AbstractNode>();

            eflags.Add(op14);
            eflags.Add(op13);
            eflags.Add(op12);
            eflags.Add(op11);
            eflags.Add(this.astCtxt.bvfalse()); /* vm */
            eflags.Add(this.astCtxt.bvfalse()); /* rf */
            eflags.Add(this.astCtxt.bvfalse()); /* Reserved */
            eflags.Add(op10);
            eflags.Add(this.astCtxt.bvfalse()); /* iopl */
            eflags.Add(this.astCtxt.bvfalse()); /* iopl */
            eflags.Add(op9);
            eflags.Add(op8);
            eflags.Add(op7);
            eflags.Add(op6);
            eflags.Add(op5);
            eflags.Add(op4);
            eflags.Add(this.astCtxt.bvfalse()); /* Reserved */
            eflags.Add(op3);
            eflags.Add(this.astCtxt.bvfalse()); /* Reserved */
            eflags.Add(op2);
            eflags.Add(this.astCtxt.bvtrue()); /* Reserved */
            eflags.Add(op1);

            var node = this.astCtxt.zx(
                          dst.BitSize - (uint)(eflags.Count()),
                          this.astCtxt.concat(eflags)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PUSHFD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pushfq_s(Instruction inst)
        {
            var stack = this.architecture.GetStackPointer();

            /* Create the semantics - side effect */
            var stackValue = alignSubStack_s(inst, stack.Size);
            var dst = new MemoryNode(stackValue, stack.BitSize);
            var src1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var src2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            var src3 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            var src4 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));
            var src5 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var src6 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_TF));
            var src7 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_IF));
            var src8 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));
            var src9 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var src10 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_NT));
            var src11 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AC));
            var src12 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_VIF));
            var src13 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_VIP));
            var src14 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ID));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);
            var op3 = this.astBuilder.GetOperandAst(inst, src3);
            var op4 = this.astBuilder.GetOperandAst(inst, src4);
            var op5 = this.astBuilder.GetOperandAst(inst, src5);
            var op6 = this.astBuilder.GetOperandAst(inst, src6);
            var op7 = this.astBuilder.GetOperandAst(inst, src7);
            var op8 = this.astBuilder.GetOperandAst(inst, src8);
            var op9 = this.astBuilder.GetOperandAst(inst, src9);
            var op10 = this.astBuilder.GetOperandAst(inst, src10);
            var op11 = this.astBuilder.GetOperandAst(inst, src11);
            var op12 = this.astBuilder.GetOperandAst(inst, src12);
            var op13 = this.astBuilder.GetOperandAst(inst, src13);
            var op14 = this.astBuilder.GetOperandAst(inst, src14);

            /* Create the semantics */
            List<AbstractNode> eflags = new List<AbstractNode>();

            eflags.Add(op14);
            eflags.Add(op13);
            eflags.Add(op12);
            eflags.Add(op11);
            eflags.Add(this.astCtxt.bvfalse()); /* vm */
            eflags.Add(this.astCtxt.bvfalse()); /* rf */
            eflags.Add(this.astCtxt.bvfalse()); /* Reserved */
            eflags.Add(op10);
            eflags.Add(this.astCtxt.bvfalse()); /* iopl */
            eflags.Add(this.astCtxt.bvfalse()); /* iopl */
            eflags.Add(op9);
            eflags.Add(op8);
            eflags.Add(op7);
            eflags.Add(op6);
            eflags.Add(op5);
            eflags.Add(op4);
            eflags.Add(this.astCtxt.bvfalse()); /* Reserved */
            eflags.Add(op3);
            eflags.Add(this.astCtxt.bvfalse()); /* Reserved */
            eflags.Add(op2);
            eflags.Add(this.astCtxt.bvtrue()); /* Reserved */
            eflags.Add(op1);

            var node = this.astCtxt.zx(
                          dst.BitSize - (uint)(eflags.Count()),
                          this.astCtxt.concat(eflags)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PUSHFQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void pxor_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvxor(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "PXOR operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void rcl_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var srcCf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op2bis = this.astBuilder.GetOperandAst(src);
            var op3 = this.astBuilder.GetOperandAst(inst, srcCf);

            switch (dst.BitSize)
            {
                /* Mask: 0x1f without MOD */
                case BitSizes.Qword:
                    op2 = this.astCtxt.bvand(
                            op2,
                            this.astCtxt.bv(BitSizes.Qword - 1, src.BitSize)
                          );
                    break;

                /* Mask: 0x1f without MOD */
                case BitSizes.Dword:
                    op2 = this.astCtxt.bvand(
                            op2,
                            this.astCtxt.bv(BitSizes.Dword - 1, src.BitSize)
                          );
                    break;

                /* Mask: 0x1f MOD size + 1 */
                case BitSizes.Word:
                case BitSizes.Byte:
                    op2 = this.astCtxt.bvsmod(
                            this.astCtxt.bvand(
                              op2,
                              this.astCtxt.bv(BitSizes.Dword - 1, src.BitSize)),
                            this.astCtxt.bv(dst.BitSize + 1, src.BitSize)
                          );
                    break;

                default:
                    throw new Exception("rcl_s(): Invalid destination size");
            }

            /* Create the semantics */
            var node1 = this.astCtxt.bvrol(
                           this.astCtxt.concat(op3, op1),
                           this.astCtxt.zx(((op1.BitvectorSize + op3.BitvectorSize) - op2.BitvectorSize), op2)
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "RCL tempory operation");


            /* Create the semantics */
            var node2 = this.astCtxt.extract(dst.BitSize - 1, 0, node1);

            /* Create symbolic expression */
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst, "RCL operation");


            /* Update symbolic flags */
            this.cfRcl_s(inst, expr2, node1, op2bis);
            this.ofRol_s(inst, expr2, dst, op2bis); /* Same as ROL */

            /* Tag undefined flags */
            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), this.astCtxt.bvugt(op2, astCtxt.bv(0x1, op2.BitvectorSize)));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void rcr_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var srcCf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, srcCf);

            switch (dst.BitSize)
            {
                /* Mask: 0x3f without MOD */
                case BitSizes.Qword:
                    op2 = this.astCtxt.bvand(
                            op2,
                            this.astCtxt.bv(BitSizes.Qword - 1, src.BitSize)
                          );
                    break;

                /* Mask: 0x1f without MOD */
                case BitSizes.Dword:
                    op2 = this.astCtxt.bvand(
                            op2,
                            this.astCtxt.bv(BitSizes.Dword - 1, src.BitSize)
                          );
                    break;

                /* Mask: 0x1f MOD size + 1 */
                case BitSizes.Word:
                case BitSizes.Byte:
                    op2 = this.astCtxt.bvsmod(
                            this.astCtxt.bvand(
                              op2,
                              this.astCtxt.bv(BitSizes.Dword - 1, src.BitSize)),
                            this.astCtxt.bv(dst.BitSize + 1, src.BitSize)
                          );
                    break;

                default:
                    throw new Exception("rcr_s(): Invalid destination size");
            }

            /* Create the semantics */
            var node1 = this.astCtxt.bvror(
                           this.astCtxt.concat(op3, op1),
                           this.astCtxt.zx(((op1.BitvectorSize + op3.BitvectorSize) - op2.BitvectorSize), op2)
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "RCR tempory operation");


            /* Create the semantics */
            var node2 = this.astCtxt.extract(dst.BitSize - 1, 0, node1);

            /* Create symbolic expression */
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst, "RCR operation");


            /* Update symbolic flags */
            this.ofRcr_s(inst, expr2, dst, op1, op2); /* OF must be set before CF */
            this.cfRcr_s(inst, expr2, dst, node1, op2);

            /* Tag undefined flags */
            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), this.astCtxt.bvugt(op2, astCtxt.bv(0x1, op2.BitvectorSize)));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void rdtsc_s(Instruction inst)
        {
            var dst1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EDX));
            var dst2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EAX));

            /* Create symbolic operands */
            var op1 = this.astCtxt.bv(0, dst1.BitSize);
            var op2 = this.astCtxt.bv((ulong)this.ExpressionDatabase.GetSymbolicExpressions().Count(), dst2.BitSize);

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, op1, dst1, "RDTSC EDX operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, op2, dst2, "RDTSC EAX operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void ret_s(Instruction inst)
        {
            var stack = this.architecture.GetStackPointer();
            var stackValue = this.astBuilder.GetRegisterAst(stack);
            var pc = new OperandWrapper(this.architecture.GetProgramCounter());
            var sp = new OperandWrapper(new MemoryAccess() { Size = stack.Size, BaseRegister = stack });

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, sp);

            /* Create the semantics */
            var node = op1;

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, pc, "Program Counter");


            /* Create the semantics - side effect */
            alignAddStack_s(inst, sp.Size);

            /* Create the semantics - side effect */
            //if (inst.Operands.Count() > 0)
            if(false)
            {
                var offset = inst.Operands[0].Immediate;
                this.astBuilder.GetImmediateAst(inst, offset);
                alignAddStack_s(inst, (uint)(offset.Value));
            }

            /* Create the path constraint */
            this.ExpressionDatabase.StorePathConstraint(inst, expr);
        }


        void rol_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op2bis = this.astBuilder.GetOperandAst(src);

            switch (dst.BitSize)
            {
                /* Mask 0x3f MOD size */
                case BitSizes.Qword:
                    op2 = this.astCtxt.bvsmod(
                            this.astCtxt.bvand(
                              op2,
                              this.astCtxt.bv(BitSizes.Qword - 1, src.BitSize)),
                            this.astCtxt.bv(dst.BitSize, src.BitSize)
                          );

                    op2bis = this.astCtxt.bvand(
                               op2bis,
                               this.astCtxt.bv(BitSizes.Qword - 1, src.BitSize)
                             );
                    break;

                /* Mask 0x1f MOD size */
                case BitSizes.Dword:
                case BitSizes.Word:
                case BitSizes.Byte:
                    op2 = this.astCtxt.bvsmod(
                            this.astCtxt.bvand(
                              op2,
                              this.astCtxt.bv(BitSizes.Dword - 1, src.BitSize)),
                            this.astCtxt.bv(dst.BitSize, src.BitSize)
                          );

                    op2bis = this.astCtxt.bvand(
                               op2bis,
                               this.astCtxt.bv(BitSizes.Dword - 1, src.BitSize)
                             );
                    break;

                default:
                    throw new Exception("rol_s(): Invalid destination size");
            }

            /* Create the semantics */
            var node = this.astCtxt.bvrol(
                          op1,
                          this.astCtxt.zx(op1.BitvectorSize - op2.BitvectorSize, op2)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "ROL operation");


            /* Update symbolic flags */
            this.cfRol_s(inst, expr, dst, op2bis);
            this.ofRol_s(inst, expr, dst, op2bis);

            /* Tag undefined flags */
            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), this.astCtxt.bvugt(op2, astCtxt.bv(0x1, op2.BitvectorSize)));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void ror_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op2bis = this.astBuilder.GetOperandAst(src);

            switch (dst.BitSize)
            {
                /* Mask 0x3f MOD size */
                case BitSizes.Qword:
                    op2 = this.astCtxt.bvsmod(
                            this.astCtxt.bvand(
                              op2,
                              this.astCtxt.bv(BitSizes.Qword - 1, src.BitSize)),
                            this.astCtxt.bv(dst.BitSize, src.BitSize)
                          );

                    op2bis = this.astCtxt.bvand(
                               op2bis,
                               this.astCtxt.bv(BitSizes.Qword - 1, src.BitSize)
                             );
                    break;

                /* Mask 0x1f MOD size */
                case BitSizes.Dword:
                case BitSizes.Word:
                case BitSizes.Byte:
                    op2 = this.astCtxt.bvsmod(
                            this.astCtxt.bvand(
                              op2,
                              this.astCtxt.bv(BitSizes.Dword - 1, src.BitSize)),
                            this.astCtxt.bv(dst.BitSize, src.BitSize)
                          );

                    op2bis = this.astCtxt.bvand(
                               op2bis,
                               this.astCtxt.bv(BitSizes.Dword - 1, src.BitSize)
                             );
                    break;

                default:
                    throw new Exception("ror_s(): Invalid destination size");
            }

            /* Create the semantics */
            var node = this.astCtxt.bvror(
                          op1,
                          this.astCtxt.zx(op1.BitvectorSize - op2.BitvectorSize, op2)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "ROR operation");


            /* Update symbolic flags */
            this.cfRor_s(inst, expr, dst, op2);
            this.ofRor_s(inst, expr, dst, op2bis);

            /* Tag undefined flags */
            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), this.astCtxt.bvugt(op2, astCtxt.bv(0x1, op2.BitvectorSize)));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void rorx_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            switch (dst.BitSize)
            {
                /* Mask 0x3f MOD size */
                case BitSizes.Qword:
                    op2 = this.astCtxt.bvand(op2, this.astCtxt.bv(BitSizes.Qword - 1, src2.BitSize));
                    break;

                /* Mask 0x1f MOD size */
                case BitSizes.Dword:
                    op2 = this.astCtxt.bvand(op2, this.astCtxt.bv(BitSizes.Dword - 1, src2.BitSize));
                    break;

                default:
                    throw new Exception("rorx_s(): Invalid destination size");
            }

            /* Create the semantics */
            var node = this.astCtxt.bvror(
                          op1,
                          this.astCtxt.zx(op1.BitvectorSize - op2.BitvectorSize, op2)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "RORX operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void sahf_s(Instruction inst)
        {
            var dst1 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var dst2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));
            var dst3 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            var dst4 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            var dst5 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var src = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_AH));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node1 = this.astCtxt.extract(7, 7, op1);
            var node2 = this.astCtxt.extract(6, 6, op1);
            var node3 = this.astCtxt.extract(4, 4, op1);
            var node4 = this.astCtxt.extract(2, 2, op1);
            var node5 = this.astCtxt.extract(0, 0, op1);

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst1.Register, "SAHF SF operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, dst2.Register, "SAHF ZF operation");
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, dst3.Register, "SAHF AF operation");
            var expr4 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node4, dst4.Register, "SAHF PF operation");
            var expr5 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node5, dst5.Register, "SAHF CF operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void sar_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astCtxt.zx(dst.BitSize - src.BitSize, this.astBuilder.GetOperandAst(inst, src));

            if (dst.BitSize == BitSizes.Qword)
                op2 = this.astCtxt.bvand(op2, this.astCtxt.bv(BitSizes.Qword - 1, dst.BitSize));
            else
                op2 = this.astCtxt.bvand(op2, this.astCtxt.bv(BitSizes.Dword - 1, dst.BitSize));

            /* Create the semantics */
            var node = this.astCtxt.bvashr(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SAR operation");


            /* Update symbolic flags */
            this.cfSar_s(inst, expr, dst, op1, op2);
            this.ofSar_s(inst, expr, dst, op2);
            this.pfShl_s(inst, expr, dst, op2); /* Same that shl */
            this.sfShl_s(inst, expr, dst, op2); /* Same that shl */
            this.zfShl_s(inst, expr, dst, op2); /* Same that shl */

            /* Tag undefined flags */
            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF), this.astCtxt.bvnot(this.astCtxt.equal(op2, astCtxt.bv(0x0, op2.BitvectorSize))));

            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), this.astCtxt.bvugt(op2, astCtxt.bv(0x1, op2.BitvectorSize)));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void sarx_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            switch (dst.BitSize)
            {
                /* Mask 0x3f MOD size */
                case BitSizes.Qword:
                    op2 = this.astCtxt.bvand(op2, this.astCtxt.bv(BitSizes.Qword - 1, src2.BitSize));
                    break;

                /* Mask 0x1f MOD size */
                case BitSizes.Dword:
                    op2 = this.astCtxt.bvand(op2, this.astCtxt.bv(BitSizes.Dword - 1, src2.BitSize));
                    break;

                default:
                    throw new Exception("sarx_s(): Invalid destination size");
            }

            /* Create the semantics */
            var node = this.astCtxt.bvashr(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SARX operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void sbb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var srcCf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astCtxt.zx(src.BitSize - 1, this.astBuilder.GetOperandAst(inst, srcCf));

            /* Create the semantics */
            var node = this.astCtxt.bvsub(op1, this.astCtxt.bvadd(op2, op3));

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SBB operation");


            /* Update symbolic flags */
            this.af_s(inst, expr, dst, op1, op2);
            this.cfSub_s(inst, expr, dst, op1, op2);
            this.ofSub_s(inst, expr, dst, op1, op2);
            this.pf_s(inst, expr, dst);
            this.sf_s(inst, expr, dst);
            this.zf_s(inst, expr, dst);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void scasb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* If the REP prefix is defined, convert REP into REPE */
            if (inst.Prefix == Prefix.ID_PREFIX_REP)
                inst.Prefix = Prefix.ID_PREFIX_REP;

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, index);
            var op4 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = this.astCtxt.bvsub(op1, op2);
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op4, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op3, this.astCtxt.bv(ByteSizes.Byte, index.BitSize)),
                           this.astCtxt.bvsub(op3, this.astCtxt.bv(ByteSizes.Byte, index.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "SCASB operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index, "Index operation");


            /* Update symbolic flags */
            this.af_s(inst, expr1, dst, op1, op2, true);
            this.cfSub_s(inst, expr1, dst, op1, op2, true);
            this.ofSub_s(inst, expr1, dst, op1, op2, true);
            this.pf_s(inst, expr1, dst, true);
            this.sf_s(inst, expr1, dst, true);
            this.zf_s(inst, expr1, dst, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void scasd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* If the REP prefix is defined, convert REP into REPE */
            if (inst.Prefix == Prefix.ID_PREFIX_REP)
                inst.Prefix = Prefix.ID_PREFIX_REP;

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, index);
            var op4 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = this.astCtxt.bvsub(op1, op2);
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op4, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op3, this.astCtxt.bv(ByteSizes.Dword, index.BitSize)),
                           this.astCtxt.bvsub(op3, this.astCtxt.bv(ByteSizes.Dword, index.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "SCASD operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index, "Index operation");


            /* Update symbolic flags */
            this.af_s(inst, expr1, dst, op1, op2, true);
            this.cfSub_s(inst, expr1, dst, op1, op2, true);
            this.ofSub_s(inst, expr1, dst, op1, op2, true);
            this.pf_s(inst, expr1, dst, true);
            this.sf_s(inst, expr1, dst, true);
            this.zf_s(inst, expr1, dst, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void scasq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* If the REP prefix is defined, convert REP into REPE */
            if (inst.Prefix == Prefix.ID_PREFIX_REP)
                inst.Prefix = Prefix.ID_PREFIX_REP;

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, index);
            var op4 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = this.astCtxt.bvsub(op1, op2);
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op4, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op3, this.astCtxt.bv(ByteSizes.Qword, index.BitSize)),
                           this.astCtxt.bvsub(op3, this.astCtxt.bv(ByteSizes.Qword, index.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "SCASQ operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index, "Index operation");


            /* Update symbolic flags */
            this.af_s(inst, expr1, dst, op1, op2, true);
            this.cfSub_s(inst, expr1, dst, op1, op2, true);
            this.ofSub_s(inst, expr1, dst, op1, op2, true);
            this.pf_s(inst, expr1, dst, true);
            this.sf_s(inst, expr1, dst, true);
            this.zf_s(inst, expr1, dst, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void scasw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* If the REP prefix is defined, convert REP into REPE */
            if (inst.Prefix == Prefix.ID_PREFIX_REP)
                inst.Prefix = Prefix.ID_PREFIX_REP;

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, index);
            var op4 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = this.astCtxt.bvsub(op1, op2);
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op4, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op3, this.astCtxt.bv(ByteSizes.Word, index.BitSize)),
                           this.astCtxt.bvsub(op3, this.astCtxt.bv(ByteSizes.Word, index.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "SCASW operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index, "Index operation");


            /* Update symbolic flags */
            this.af_s(inst, expr1, dst, op1, op2, true);
            this.cfSub_s(inst, expr1, dst, op1, op2, true);
            this.ofSub_s(inst, expr1, dst, op1, op2, true);
            this.pf_s(inst, expr1, dst, true);
            this.sf_s(inst, expr1, dst, true);
            this.zf_s(inst, expr1, dst, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void seta_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, cf);
            var op3 = this.astBuilder.GetOperandAst(inst, zf);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(
                            this.astCtxt.bvand(
                              this.astCtxt.bvnot(op2),
                              this.astCtxt.bvnot(op3)
                            ),
                            this.astCtxt.bvtrue()
                          ),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETA operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void setae_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, cf);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bvfalse()),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETAE operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void setb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, cf);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bvtrue()),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETB operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void setbe_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var cf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_CF));
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, cf);
            var op3 = this.astBuilder.GetOperandAst(inst, zf);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(this.astCtxt.bvor(op2, op3), this.astCtxt.bvtrue()),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETBE operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void sete_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, zf);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bvtrue()),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETE operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void setg_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, sf);
            var op3 = this.astBuilder.GetOperandAst(inst, of);
            var op4 = this.astBuilder.GetOperandAst(inst, zf);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(this.astCtxt.bvor(this.astCtxt.bvxor(op2, op3), op4), this.astCtxt.bvfalse()),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETG operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void setge_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, sf);
            var op3 = this.astBuilder.GetOperandAst(inst, of);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, op3),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETGE operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void setl_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, sf);
            var op3 = this.astBuilder.GetOperandAst(inst, of);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(this.astCtxt.bvxor(op2, op3), this.astCtxt.bvtrue()),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETL operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void setle_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, sf);
            var op3 = this.astBuilder.GetOperandAst(inst, of);
            var op4 = this.astBuilder.GetOperandAst(inst, zf);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(this.astCtxt.bvor(this.astCtxt.bvxor(op2, op3), op4), this.astCtxt.bvtrue()),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETLE operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void setne_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var zf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_ZF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, zf);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bvfalse()),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETNE operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void setno_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, of);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bvfalse()),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETNO operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void setnp_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var pf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_PF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, pf);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bvfalse()),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETNP operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void setns_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, sf);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bvfalse()),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETNS operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void seto_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var of = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_OF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, of);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bvtrue()),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETO operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void setp_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var pf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_PF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, pf);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bvtrue()),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETP operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void sets_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var sf = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_SF));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, sf);

            /* Create the semantics */
            var node = this.astCtxt.ite(
                          this.astCtxt.equal(op2, this.astCtxt.bvtrue()),
                          this.astCtxt.bv(1, dst.BitSize),
                          this.astCtxt.bv(0, dst.BitSize)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SETS operation");

            /* Set condition flag */


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void sfence_s(Instruction inst)
        {
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void shl_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astCtxt.zx(dst.BitSize - src.BitSize, this.astBuilder.GetOperandAst(inst, src));
            var op2bis = op2;

            if (dst.BitSize == BitSizes.Qword)
                op2 = this.astCtxt.bvand(op2, this.astCtxt.bv(BitSizes.Qword - 1, dst.BitSize));
            else
                op2 = this.astCtxt.bvand(op2, this.astCtxt.bv(BitSizes.Dword - 1, dst.BitSize));

            /* Create the semantics */
            var node = this.astCtxt.bvshl(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SHL operation");


            /* Update symbolic flags */
            this.cfShl_s(inst, expr, dst, op1, op2);
            this.ofShl_s(inst, expr, dst, op1, op2);
            this.pfShl_s(inst, expr, dst, op2);
            this.sfShl_s(inst, expr, dst, op2);
            this.zfShl_s(inst, expr, dst, op2);

            /* Tag undefined flags */
            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF), this.astCtxt.bvnot(this.astCtxt.equal(op2, astCtxt.bv(0x0, op2.BitvectorSize))));

            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF), this.astCtxt.bvugt(op2bis, astCtxt.bv(dst.BitSize, op2bis.BitvectorSize)));

            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), this.astCtxt.bvugt(op2, astCtxt.bv(0x1, op2.BitvectorSize)));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void shld_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);
            var op3bis = op3;

            switch (dst.BitSize)
            {
                /* Mask 0x3f MOD size */
                case BitSizes.Qword:
                    op3 = this.astCtxt.bvsmod(
                            this.astCtxt.bvand(
                              op3,
                              this.astCtxt.bv(BitSizes.Qword - 1, src2.BitSize)),
                            this.astCtxt.bv(dst.BitSize, src2.BitSize)
                          );
                    break;

                /* Mask 0x1f MOD size */
                case BitSizes.Dword:
                case BitSizes.Word:
                    op3 = this.astCtxt.bvsmod(
                            this.astCtxt.bvand(
                              op3,
                              this.astCtxt.bv(BitSizes.Dword - 1, src2.BitSize)),
                            this.astCtxt.bv(BitSizes.Dword, src2.BitSize)
                          );
                    break;

                default:
                    throw new Exception("shld_s(): Invalid destination size");
            }

            /* Create the semantics */
            var node = this.astCtxt.extract(
                          dst.BitSize - 1, 0,
                          this.astCtxt.bvrol(
                            this.astCtxt.concat(op2, op1),
                            this.astCtxt.zx(((op1.BitvectorSize + op2.BitvectorSize) - op3.BitvectorSize), op3)
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SHLD operation");


            /* Update symbolic flags */
            this.cfShld_s(inst, expr, dst, op1, op2, op3);
            this.ofShld_s(inst, expr, dst, op1, op2, op3);
            this.pfShl_s(inst, expr, dst, op3); /* Same that shl */
            this.sfShld_s(inst, expr, dst, op1, op2, op3);
            this.zfShl_s(inst, expr, dst, op3); /* Same that shl */

            /* Tag undefined flags */
            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF), this.astCtxt.bvnot(this.astCtxt.equal(op3, astCtxt.bv(0x0, op3.BitvectorSize))));

            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), this.astCtxt.bvugt(op3, astCtxt.bv(0x1, op3.BitvectorSize)));

            if (true)
            {
                this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF), this.astCtxt.bvugt(op3bis, astCtxt.bv(dst.BitSize, op3bis.BitvectorSize)));
                this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF), this.astCtxt.bvugt(op3bis, astCtxt.bv(dst.BitSize, op3bis.BitvectorSize)));
                this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), this.astCtxt.bvugt(op3bis, astCtxt.bv(dst.BitSize, op3bis.BitvectorSize)));
                this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF), this.astCtxt.bvugt(op3bis, astCtxt.bv(dst.BitSize, op3bis.BitvectorSize)));
                this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF), this.astCtxt.bvugt(op3bis, astCtxt.bv(dst.BitSize, op3bis.BitvectorSize)));
                this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_ZF), this.astCtxt.bvugt(op3bis, astCtxt.bv(dst.BitSize, op3bis.BitvectorSize)));
                if (dst.Type == OperandType.Reg)
                    this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF), this.astCtxt.bvugt(op3bis, astCtxt.bv(dst.BitSize, op3bis.BitvectorSize)));
            }

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void shlx_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            switch (dst.BitSize)
            {
                /* Mask 0x3f MOD size */
                case BitSizes.Qword:
                    op2 = this.astCtxt.bvand(op2, this.astCtxt.bv(BitSizes.Qword - 1, src2.BitSize));
                    break;

                /* Mask 0x1f MOD size */
                case BitSizes.Dword:
                    op2 = this.astCtxt.bvand(op2, this.astCtxt.bv(BitSizes.Dword - 1, src2.BitSize));
                    break;

                default:
                    throw new Exception("shlx_s(): Invalid destination size");
            }

            /* Create the semantics */
            var node = this.astCtxt.bvshl(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SHLX operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void shr_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astCtxt.zx(dst.BitSize - src.BitSize, this.astBuilder.GetOperandAst(inst, src));
            var op2bis = op2;

            if (dst.BitSize == BitSizes.Qword)
                op2 = this.astCtxt.bvand(op2, this.astCtxt.bv(BitSizes.Qword - 1, dst.BitSize));
            else
                op2 = this.astCtxt.bvand(op2, this.astCtxt.bv(BitSizes.Dword - 1, dst.BitSize));

            /* Create the semantics */
            var node = this.astCtxt.bvlshr(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SHR operation");


            /* Update symbolic flags */
            this.cfShr_s(inst, expr, dst, op1, op2);
            this.ofShr_s(inst, expr, dst, op1, op2);
            this.pfShl_s(inst, expr, dst, op2); /* Same that shl */
            this.sfShl_s(inst, expr, dst, op2); /* Same that shl */
            this.zfShl_s(inst, expr, dst, op2); /* Same that shl */

            /* Tag undefined flags */
            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF), this.astCtxt.bvnot(this.astCtxt.equal(op2, astCtxt.bv(0x0, op2.BitvectorSize))));

            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF), this.astCtxt.bvugt(op2bis, astCtxt.bv(dst.BitSize, op2bis.BitvectorSize)));

            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), this.astCtxt.bvugt(op2, astCtxt.bv(0x1, op2.BitvectorSize)));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void shrd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);
            var op3bis = op3;

            switch (dst.BitSize)
            {
                /* Mask 0x3f MOD size */
                case BitSizes.Qword:
                    op3 = this.astCtxt.bvsmod(
                            this.astCtxt.bvand(
                              op3,
                              this.astCtxt.bv(BitSizes.Qword - 1, src2.BitSize)),
                            this.astCtxt.bv(dst.BitSize, src2.BitSize)
                          );
                    break;

                /* Mask 0x1f MOD size */
                case BitSizes.Dword:
                case BitSizes.Word:
                    op3 = this.astCtxt.bvsmod(
                            this.astCtxt.bvand(
                              op3,
                              this.astCtxt.bv(BitSizes.Dword - 1, src2.BitSize)),
                            this.astCtxt.bv(BitSizes.Dword, src2.BitSize)
                          );
                    break;

                default:
                    throw new Exception("shrd_s(): Invalid destination size");
            }

            /* Create the semantics */
            var node = this.astCtxt.extract(
                          dst.BitSize - 1, 0,
                          this.astCtxt.bvror(
                            this.astCtxt.concat(op2, op1),
                            this.astCtxt.zx(((op1.BitvectorSize + op2.BitvectorSize) - op3.BitvectorSize), op3)
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SHRD operation");


            /* Update symbolic flags */
            this.cfShrd_s(inst, expr, dst, op1, op2, op3);
            this.ofShrd_s(inst, expr, dst, op1, op2, op3);
            this.pfShl_s(inst, expr, dst, op3); /* Same that shl */
            this.sfShrd_s(inst, expr, dst, op1, op2, op3);
            this.zfShl_s(inst, expr, dst, op3); /* Same that shl */

            /* Tag undefined flags */
            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF), this.astCtxt.bvnot(this.astCtxt.equal(op3, astCtxt.bv(0x0, op3.BitvectorSize))));

            this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), this.astCtxt.bvugt(op3, astCtxt.bv(0x1, op3.BitvectorSize)));

            if (true)
            {
                this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF), this.astCtxt.bvugt(op3bis, astCtxt.bv(dst.BitSize, op3bis.BitvectorSize)));
                this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF), this.astCtxt.bvugt(op3bis, astCtxt.bv(dst.BitSize, op3bis.BitvectorSize)));
                this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), this.astCtxt.bvugt(op3bis, astCtxt.bv(dst.BitSize, op3bis.BitvectorSize)));
                this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF), this.astCtxt.bvugt(op3bis, astCtxt.bv(dst.BitSize, op3bis.BitvectorSize)));
                this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF), this.astCtxt.bvugt(op3bis, astCtxt.bv(dst.BitSize, op3bis.BitvectorSize)));
                this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_ZF), this.astCtxt.bvugt(op3bis, astCtxt.bv(dst.BitSize, op3bis.BitvectorSize)));
                if (dst.Type == OperandType.Reg)
                    this.ConditionalUndefine(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF), this.astCtxt.bvugt(op3bis, astCtxt.bv(dst.BitSize, op3bis.BitvectorSize)));
            }

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void shrx_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            switch (dst.BitSize)
            {
                /* Mask 0x3f MOD size */
                case BitSizes.Qword:
                    op2 = this.astCtxt.bvand(op2, this.astCtxt.bv(BitSizes.Qword - 1, src2.BitSize));
                    break;

                /* Mask 0x1f MOD size */
                case BitSizes.Dword:
                    op2 = this.astCtxt.bvand(op2, this.astCtxt.bv(BitSizes.Dword - 1, src2.BitSize));
                    break;

                default:
                    throw new Exception("shrx_s(): Invalid destination size");
            }

            /* Create the semantics */
            var node = this.astCtxt.bvlshr(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SHRX operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void stc_s(Instruction inst)
        {
            this.setFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Sets carry flag");
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void std_s(Instruction inst)
        {
            this.setFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_DF), "Sets direction flag");
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void sti_s(Instruction inst)
        {
            this.setFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_IF), "Sets interrupt flag");
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void stmxcsr_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_MXCSR));

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.extract(BitSizes.Dword - 1, 0, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "STMXCSR operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void stosb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);
            var op2 = this.astBuilder.GetOperandAst(inst, index);
            var op3 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = op1;
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op3, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op2, this.astCtxt.bv(ByteSizes.Byte, index.BitSize)),
                           this.astCtxt.bvsub(op2, this.astCtxt.bv(ByteSizes.Byte, index.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "STOSB operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index, "Index operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void stosd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);
            var op2 = this.astBuilder.GetOperandAst(inst, index);
            var op3 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = op1;
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op3, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op2, this.astCtxt.bv(ByteSizes.Dword, index.BitSize)),
                           this.astCtxt.bvsub(op2, this.astCtxt.bv(ByteSizes.Dword, index.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "STOSD operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index, "Index operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void stosq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);
            var op2 = this.astBuilder.GetOperandAst(inst, index);
            var op3 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = op1;
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op3, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op2, this.astCtxt.bv(ByteSizes.Qword, index.BitSize)),
                           this.astCtxt.bvsub(op2, this.astCtxt.bv(ByteSizes.Qword, index.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "STOSQ operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index, "Index operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void stosw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var index = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_DI));
            var cx = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var df = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_DF));

            /* Check if there is a REP prefix and a counter to zero */
            if (inst.Prefix != Prefix.ID_PREFIX_INVALID && this.astBuilder.GetOperandAst(cx).Evaluate().IsZero())
            {
                this.controlFlow_s(inst);
                return;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);
            var op2 = this.astBuilder.GetOperandAst(inst, index);
            var op3 = this.astBuilder.GetOperandAst(inst, df);

            /* Create the semantics */
            var node1 = op1;
            var node2 = this.astCtxt.ite(
                           this.astCtxt.equal(op3, this.astCtxt.bvfalse()),
                           this.astCtxt.bvadd(op2, this.astCtxt.bv(ByteSizes.Word, index.BitSize)),
                           this.astCtxt.bvsub(op2, this.astCtxt.bv(ByteSizes.Word, index.BitSize))
                         );

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "STOSW operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, index, "Index operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void sub_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvsub(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "SUB operation");


            /* Update symbolic flags */
            this.af_s(inst, expr, dst, op1, op2);
            this.cfSub_s(inst, expr, dst, op1, op2);
            this.ofSub_s(inst, expr, dst, op1, op2);
            this.pf_s(inst, expr, dst);
            this.sf_s(inst, expr, dst);
            this.zf_s(inst, expr, dst);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void syscall_s(Instruction inst)
        {
            var dst1 = new OperandWrapper(this.architecture.GetParentRegister(register_e.ID_REG_X86_CX));
            var src1 = new OperandWrapper(this.architecture.GetProgramCounter());

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);

            /* Create the semantics */
            var node1 = this.astCtxt.bvadd(op1, this.astCtxt.bv(inst.Size, src1.BitSize));

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst1, "SYSCALL RCX operation");


            /* 64-bit */
            if (src1.BitSize == 64)
            {
                var dst2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_R11));
                var src2 = new OperandWrapper(this.architecture.GetRegister(register_e.ID_REG_X86_EFLAGS));
                /* Create symbolic operands */
                var op2 = this.astBuilder.GetOperandAst(inst, src2);
                /* Create symbolic expression */
                var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, op2, dst2, "SYSCALL R11 operation");
            }

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void sysenter_s(Instruction inst)
        {
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void test_s(Instruction inst)
        {
            var src1 = inst.Operands[0];
            var src2 = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            var node = this.astCtxt.bvand(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicExpression(inst, node, "TEST operation");


            /* Update symbolic flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Clears carry flag");
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Clears overflow flag");
            this.pf_s(inst, expr, src1, true);
            this.sf_s(inst, expr, src1, true);
            this.zf_s(inst, expr, src1, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void tzcnt_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var bvSize1 = dst.BitSize;
            var bvSize2 = src.BitSize;

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            AbstractNode node = null;
            switch (src.Size)
            {
                case ByteSizes.Byte:
                    node = this.astCtxt.ite(
                             this.astCtxt.equal(op1, this.astCtxt.bv(0, bvSize2)),
                             this.astCtxt.bv(bvSize1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(0, 0, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(1, 1, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(2, 2, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(3, 3, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(4, 4, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(5, 5, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(6, 6, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(7, 7, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                             this.astCtxt.bv(0, bvSize1)
                             ))))))))
                           );
                    break;
                case ByteSizes.Word:
                    node = this.astCtxt.ite(
                             this.astCtxt.equal(op1, this.astCtxt.bv(0, bvSize2)),
                             this.astCtxt.bv(bvSize1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(0, 0, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(1, 1, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(2, 2, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(3, 3, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(4, 4, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(5, 5, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(6, 6, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(7, 7, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(8, 8, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(8, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(9, 9, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(9, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(10, 10, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(10, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(11, 11, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(11, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(12, 12, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(12, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(13, 13, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(13, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(14, 14, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(14, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(15, 15, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(15, bvSize1),
                             this.astCtxt.bv(0, bvSize1)
                             ))))))))))))))))
                           );
                    break;
                case ByteSizes.Dword:
                    node = this.astCtxt.ite(
                             this.astCtxt.equal(op1, this.astCtxt.bv(0, bvSize2)),
                             this.astCtxt.bv(bvSize1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(0, 0, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(1, 1, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(2, 2, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(3, 3, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(4, 4, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(5, 5, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(6, 6, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(7, 7, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(8, 8, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(8, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(9, 9, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(9, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(10, 10, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(10, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(11, 11, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(11, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(12, 12, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(12, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(13, 13, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(13, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(14, 14, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(14, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(15, 15, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(15, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(16, 16, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(16, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(17, 17, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(17, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(18, 18, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(18, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(19, 19, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(19, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(20, 20, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(20, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(21, 21, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(21, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(22, 22, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(22, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(23, 23, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(23, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(24, 24, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(24, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(25, 25, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(25, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(26, 26, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(26, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(27, 27, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(27, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(28, 28, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(28, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(29, 29, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(29, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(30, 30, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(30, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(31, 31, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(31, bvSize1),
                             this.astCtxt.bv(0, bvSize1)
                             ))))))))))))))))))))))))))))))))
                           );
                    break;
                case ByteSizes.Qword:
                    node = this.astCtxt.ite(
                             this.astCtxt.equal(op1, this.astCtxt.bv(0, bvSize2)),
                             this.astCtxt.bv(bvSize1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(0, 0, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(0, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(1, 1, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(1, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(2, 2, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(2, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(3, 3, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(3, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(4, 4, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(4, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(5, 5, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(5, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(6, 6, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(6, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(7, 7, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(7, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(8, 8, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(8, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(9, 9, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(9, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(10, 10, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(10, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(11, 11, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(11, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(12, 12, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(12, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(13, 13, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(13, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(14, 14, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(14, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(15, 15, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(15, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(16, 16, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(16, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(17, 17, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(17, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(18, 18, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(18, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(19, 19, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(19, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(20, 20, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(20, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(21, 21, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(21, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(22, 22, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(22, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(23, 23, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(23, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(24, 24, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(24, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(25, 25, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(25, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(26, 26, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(26, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(27, 27, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(27, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(28, 28, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(28, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(29, 29, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(29, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(30, 30, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(30, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(31, 31, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(31, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(32, 32, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(32, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(33, 33, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(33, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(34, 34, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(34, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(35, 35, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(35, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(36, 36, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(36, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(37, 37, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(37, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(38, 38, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(38, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(39, 39, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(39, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(40, 40, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(40, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(41, 41, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(41, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(42, 42, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(42, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(43, 43, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(43, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(44, 44, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(44, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(45, 45, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(45, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(46, 46, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(46, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(47, 47, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(47, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(48, 48, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(48, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(49, 49, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(49, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(50, 50, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(50, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(51, 51, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(51, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(52, 52, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(52, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(53, 53, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(53, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(54, 54, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(54, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(55, 55, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(55, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(56, 56, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(56, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(57, 57, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(57, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(58, 58, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(58, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(59, 59, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(59, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(60, 60, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(60, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(61, 61, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(61, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(62, 62, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(62, bvSize1),
                             this.astCtxt.ite(this.astCtxt.equal(this.astCtxt.extract(63, 63, op1), this.astCtxt.bvtrue()), this.astCtxt.bv(63, bvSize1),
                             this.astCtxt.bv(0, bvSize1)
                             ))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))
                           );
                    break;
                default:
                    throw new Exception("tzcnt_s(): Invalid operand size.");
            }

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "TZCNT operation");


            /* Update symbolic flags */
            this.cfTzcnt_s(inst, expr, src, op1);
            this.zf_s(inst, expr, src);

            /* Tag undefined flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF));
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void unpckhpd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.concat(
                          this.astCtxt.extract(127, 64, op2),
                          this.astCtxt.extract(127, 64, op1)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "UNPCKHPD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void unpckhps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> unpack = new List<AbstractNode>();

            unpack.Add(this.astCtxt.extract(127, 96, op2));
            unpack.Add(this.astCtxt.extract(127, 96, op1));
            unpack.Add(this.astCtxt.extract(95, 64, op2));
            unpack.Add(this.astCtxt.extract(95, 64, op1));

            var node = this.astCtxt.concat(unpack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "UNPCKHPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void unpcklpd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.concat(
                          this.astCtxt.extract(63, 0, op2),
                          this.astCtxt.extract(63, 0, op1)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "UNPCKLPD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void unpcklps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> unpack = new List<AbstractNode>();

            unpack.Add(this.astCtxt.extract(63, 32, op2));
            unpack.Add(this.astCtxt.extract(63, 32, op1));
            unpack.Add(this.astCtxt.extract(31, 0, op2));
            unpack.Add(this.astCtxt.extract(31, 0, op1));

            var node = this.astCtxt.concat(unpack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "UNPCKLPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vmovd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.extract(BitSizes.Dword - 1, 0, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VMOVD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vmovdqa_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VMOVDQA operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vmovdqu_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VMOVDQU operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vmovq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.extract(BitSizes.Qword - 1, 0, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VMOVQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vmovsd_s(Instruction inst)
        {
            /* Move scalar double-precision floating-point value */
            if (inst.Operands.Count() == 2)
            {
                var dst = inst.Operands[0];
                var src = inst.Operands[1];

                /* Create symbolic operands */
                var op1 = this.astBuilder.GetOperandAst(inst, dst);
                var op2 = this.astBuilder.GetOperandAst(inst, src);

                /* Create the semantics */
                AbstractNode node;
                if (dst.Size == ByteSizes.Dqword && src.Size == ByteSizes.Qword)
                {
                    /* VEX.LIG.F2.0F.WIG 10 /r VMOVSD xmm1, m64 */
                    node = op2;
                }
                else if (dst.Size == ByteSizes.Qword && src.Size == ByteSizes.Dqword)
                {
                    /* VEX.LIG.F2.0F.WIG 11 /r VMOVSD m64, xmm1 */
                    node = this.astCtxt.extract(BitSizes.Qword - 1, 0, op2);
                }
                else
                {
                    throw new Exception("vmovsd_s(): Invalid operand size.");
                }

                /* Create symbolic expression */
                var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VMOVSD operation");

            }

            /* Merge scalar double-precision floating-point value
             *
             * VEX.NDS.LIG.F2.0F.WIG 10 /r VMOVSD xmm1, xmm2, xmm3
             * VEX.NDS.LIG.F2.0F.WIG 11 /r VMOVSD xmm1, xmm2, xmm3
             */
            else if (inst.Operands.Count() == 3)
            {
                var dst = inst.Operands[0];
                var src1 = inst.Operands[1];
                var src2 = inst.Operands[2];

                /* Create symbolic operands */
                var op1 = this.astBuilder.GetOperandAst(inst, dst);
                var op2 = this.astBuilder.GetOperandAst(inst, src1);
                var op3 = this.astBuilder.GetOperandAst(inst, src2);

                /* Create the semantics */
                var node = this.astCtxt.concat(
                              this.astCtxt.extract(BitSizes.Dqword - 1, BitSizes.Qword, op2),
                              this.astCtxt.extract(BitSizes.Qword - 1, 0, op3)
                            );

                /* Create symbolic expression */
                var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VMOVSD operation");

            }

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vmovaps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VMOVAPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vmovups_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create the semantics */
            var node = this.astBuilder.GetOperandAst(inst, src);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VMOVUPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpand_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            var node = this.astCtxt.bvand(op2, op3);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPAND operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpandn_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            var node = this.astCtxt.bvand(this.astCtxt.bvnot(op2), op3);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPANDN operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpextrb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            var node = this.astCtxt.extract(7, 0,
                          this.astCtxt.bvlshr(
                            op2,
                            this.astCtxt.bv(((op3.Evaluate() & 0x0f) * 8), op2.BitvectorSize)
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPEXTRB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpextrd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            var node = this.astCtxt.extract(BitSizes.Dword - 1, 0,
                          this.astCtxt.bvlshr(
                            op2,
                            this.astCtxt.bv(((op3.Evaluate() & 0x3) * BitSizes.Dword), op2.BitvectorSize)
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPEXTRD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpextrq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            var node = this.astCtxt.extract(BitSizes.Qword - 1, 0,
                          this.astCtxt.bvlshr(
                            op2,
                            this.astCtxt.bv(((op3.Evaluate() & 0x1) * BitSizes.Qword), op2.BitvectorSize)
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPEXTRQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpextrw_s(Instruction inst)
        {
            uint count = 0;
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /*
             * When specifying a word location in an MMX technology register, the
             * 2 least-significant bits of the count operand specify the location;
             * for an XMM register, the 3 least-significant bits specify the
             * location.
             */
            if (src1.BitSize == BitSizes.Qword)
            {
                count = 0x03;
            }
            else
            {
                count = 0x07;
            }

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            var node = this.astCtxt.extract(BitSizes.Word - 1, 0,
                          this.astCtxt.bvlshr(
                            op2,
                            this.astCtxt.bv(((op3.Evaluate() & count) * BitSizes.Word), op2.BitvectorSize)
                          )
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPEXTRW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpbroadcastb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var src_node = this.astCtxt.extract(BitSizes.Byte - 1, 0, op);
            List<AbstractNode> exprs = new List<AbstractNode>() { new IntegerNode(dst.Size, src_node.BitvectorSize), src_node };
            var node = this.astCtxt.concat(exprs);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPBROADCASTB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpcmpeqb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < src1.Size; index++)
            {
                uint high = (src1.BitSize - 1) - (index * BitSizes.Byte);
                uint low = (src1.BitSize - BitSizes.Byte) - (index * BitSizes.Byte);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.equal(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.bv(0xff, BitSizes.Byte),
                                this.astCtxt.bv(0x00, BitSizes.Byte))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPCMPEQB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpcmpeqd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Dword; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Dword);
                uint low = (dst.BitSize - BitSizes.Dword) - (index * BitSizes.Dword);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.equal(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.bv(0xffffffff, BitSizes.Dword),
                                this.astCtxt.bv(0x00000000, BitSizes.Dword))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPCMPEQD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpcmpeqq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Qword; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Qword);
                uint low = (dst.BitSize - BitSizes.Qword) - (index * BitSizes.Qword);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.equal(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.bv(0xffffffffffffffff, BitSizes.Qword),
                                this.astCtxt.bv(0x0000000000000000, BitSizes.Qword))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPCMPEQQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpcmpeqw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Word; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Word);
                uint low = (dst.BitSize - BitSizes.Word) - (index * BitSizes.Word);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.equal(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.bv(0xffff, BitSizes.Word),
                                this.astCtxt.bv(0x0000, BitSizes.Word))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPCMPEQW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpcmpgtb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Byte);
                uint low = (dst.BitSize - BitSizes.Byte) - (index * BitSizes.Byte);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvsgt(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.bv(0xff, BitSizes.Byte),
                                this.astCtxt.bv(0x00, BitSizes.Byte))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPCMPGTB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpcmpgtd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Dword; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Dword);
                uint low = (dst.BitSize - BitSizes.Dword) - (index * BitSizes.Dword);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvsgt(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.bv(0xffffffff, BitSizes.Dword),
                                this.astCtxt.bv(0x00000000, BitSizes.Dword))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPCMPGTD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpcmpgtw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Word; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Word);
                uint low = (dst.BitSize - BitSizes.Word) - (index * BitSizes.Word);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvsgt(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.bv(0xffff, BitSizes.Word),
                                this.astCtxt.bv(0x0000, BitSizes.Word))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPCMPGTW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpmovmskb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            List<AbstractNode> mskb = new List<AbstractNode>();

            switch (src.Size)
            {
                case ByteSizes.Qqword:
                    mskb.Add(this.astCtxt.extract(255, 255, op2));
                    mskb.Add(this.astCtxt.extract(247, 247, op2));
                    mskb.Add(this.astCtxt.extract(239, 239, op2));
                    mskb.Add(this.astCtxt.extract(231, 231, op2));
                    mskb.Add(this.astCtxt.extract(223, 223, op2));
                    mskb.Add(this.astCtxt.extract(215, 215, op2));
                    mskb.Add(this.astCtxt.extract(207, 207, op2));
                    mskb.Add(this.astCtxt.extract(199, 199, op2));
                    mskb.Add(this.astCtxt.extract(191, 191, op2));
                    mskb.Add(this.astCtxt.extract(183, 183, op2));
                    mskb.Add(this.astCtxt.extract(175, 175, op2));
                    mskb.Add(this.astCtxt.extract(167, 167, op2));
                    mskb.Add(this.astCtxt.extract(159, 159, op2));
                    mskb.Add(this.astCtxt.extract(151, 151, op2));
                    mskb.Add(this.astCtxt.extract(143, 143, op2));
                    mskb.Add(this.astCtxt.extract(135, 135, op2));
                    goto case ByteSizes.Dqword;

                case ByteSizes.Dqword:
                    mskb.Add(this.astCtxt.extract(127, 127, op2));
                    mskb.Add(this.astCtxt.extract(119, 119, op2));
                    mskb.Add(this.astCtxt.extract(111, 111, op2));
                    mskb.Add(this.astCtxt.extract(103, 103, op2));
                    mskb.Add(this.astCtxt.extract(95, 95, op2));
                    mskb.Add(this.astCtxt.extract(87, 87, op2));
                    mskb.Add(this.astCtxt.extract(79, 79, op2));
                    mskb.Add(this.astCtxt.extract(71, 71, op2));
                    mskb.Add(this.astCtxt.extract(63, 63, op2));
                    mskb.Add(this.astCtxt.extract(55, 55, op2));
                    mskb.Add(this.astCtxt.extract(47, 47, op2));
                    mskb.Add(this.astCtxt.extract(39, 39, op2));
                    mskb.Add(this.astCtxt.extract(31, 31, op2));
                    mskb.Add(this.astCtxt.extract(23, 23, op2));
                    mskb.Add(this.astCtxt.extract(15, 15, op2));
                    mskb.Add(this.astCtxt.extract(7, 7, op2));
                    break;

                default:
                    throw new Exception("vpmovmskb_s(): Invalid operand size.");
            }

            var node = this.astCtxt.zx(
                          dst.BitSize - (uint)(mskb.Count()),
                          this.astCtxt.concat(mskb)
                        );

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPMOVMSKB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpminub_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Byte);
                uint low = (dst.BitSize - BitSizes.Byte) - (index * BitSizes.Byte);
                pck.Add(this.astCtxt.ite(
                                this.astCtxt.bvuge(
                                  this.astCtxt.extract(high, low, op1),
                                  this.astCtxt.extract(high, low, op2)),
                                this.astCtxt.extract(high, low, op2),
                                this.astCtxt.extract(high, low, op1))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPMINUB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpor_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            var node = this.astCtxt.bvor(op2, op3);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPOR operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpshufd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];
            var ord = inst.Operands[2];
            uint dstSize = dst.BitSize;

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src);
            var op3 = this.astBuilder.GetOperandAst(inst, ord);

            /* Create the semantics */
            List<AbstractNode> pack = new List<AbstractNode>();

            switch (dstSize)
            {

                /* YMM */
                case BitSizes.Qqword:
                    pack.Add(
                      this.astCtxt.extract(31, 0,
                        this.astCtxt.bvlshr(
                          op2,
                          this.astCtxt.bvmul(
                            this.astCtxt.zx(dstSize - 2, this.astCtxt.extract(7, 6, op3)),
                            this.astCtxt.bv(32, dstSize)
                          )
                        )
                      )
                    );
                    pack.Add(
                      this.astCtxt.extract(31, 0,
                        this.astCtxt.bvlshr(
                          op2,
                          this.astCtxt.bvmul(
                            this.astCtxt.zx(dstSize - 2, this.astCtxt.extract(5, 4, op3)),
                            this.astCtxt.bv(32, dstSize)
                          )
                        )
                      )
                    );
                    pack.Add(
                      this.astCtxt.extract(31, 0,
                        this.astCtxt.bvlshr(
                          op2,
                          this.astCtxt.bvmul(
                            this.astCtxt.zx(dstSize - 2, this.astCtxt.extract(3, 2, op3)),
                            this.astCtxt.bv(32, dstSize)
                          )
                        )
                      )
                    );
                    pack.Add(
                      this.astCtxt.extract(31, 0,
                        this.astCtxt.bvlshr(
                          op2,
                          this.astCtxt.bvmul(
                            this.astCtxt.zx(dstSize - 2, this.astCtxt.extract(1, 0, op3)),
                            this.astCtxt.bv(32, dstSize)
                          )
                        )
                      )
                    );
                    goto case BitSizes.Dqword;

                /* XMM */
                case BitSizes.Dqword:
                    pack.Add(
                      this.astCtxt.extract(31, 0,
                        this.astCtxt.bvlshr(
                          op2,
                          this.astCtxt.bvmul(
                            this.astCtxt.zx(dstSize - 2, this.astCtxt.extract(7, 6, op3)),
                            this.astCtxt.bv(32, dstSize)
                          )
                        )
                      )
                    );
                    pack.Add(
                      this.astCtxt.extract(31, 0,
                        this.astCtxt.bvlshr(
                          op2,
                          this.astCtxt.bvmul(
                            this.astCtxt.zx(dstSize - 2, this.astCtxt.extract(5, 4, op3)),
                            this.astCtxt.bv(32, dstSize)
                          )
                        )
                      )
                    );
                    pack.Add(
                      this.astCtxt.extract(31, 0,
                        this.astCtxt.bvlshr(
                          op2,
                          this.astCtxt.bvmul(
                            this.astCtxt.zx(dstSize - 2, this.astCtxt.extract(3, 2, op3)),
                            this.astCtxt.bv(32, dstSize)
                          )
                        )
                      )
                    );
                    pack.Add(
                      this.astCtxt.extract(31, 0,
                        this.astCtxt.bvlshr(
                          op2,
                          this.astCtxt.bvmul(
                            this.astCtxt.zx(dstSize - 2, this.astCtxt.extract(1, 0, op3)),
                            this.astCtxt.bv(32, dstSize)
                          )
                        )
                      )
                    );
                    break;

                default:
                    throw new Exception("vpshufd_s(): Invalid operand size.");
            }

            var node = this.astCtxt.concat(pack);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPSHUFD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpslldq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astCtxt.zx(BitSizes.Dqword - src2.BitSize, this.astBuilder.GetOperandAst(inst, src2));

            /* Create the semantics */
            AbstractNode node;

            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Dqword; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Dqword);
                uint low = (dst.BitSize - BitSizes.Dqword) - (index * BitSizes.Dqword);
                pck.Add(this.astCtxt.bvshl(
                               this.astCtxt.extract(high, low, op1),
                               this.astCtxt.bvmul(
                                 this.astCtxt.ite(
                                   this.astCtxt.bvuge(op2, this.astCtxt.bv(BitSizes.Word, BitSizes.Dqword)),
                                   this.astCtxt.bv(BitSizes.Word, BitSizes.Dqword),
                                   op2
                                 ),
                                 this.astCtxt.bv(BitSizes.Byte, BitSizes.Dqword)
                               )
                             ));
            }

            node = pck.Count() > 1 ? this.astCtxt.concat(pck) : pck[0];

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPSLLDQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpsubb_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Byte);
                uint low = (dst.BitSize - BitSizes.Byte) - (index * BitSizes.Byte);
                pck.Add(this.astCtxt.bvsub(
                                this.astCtxt.extract(high, low, op1),
                                this.astCtxt.extract(high, low, op2))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPSUBB operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpsubd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Dword; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Dword);
                uint low = (dst.BitSize - BitSizes.Dword) - (index * BitSizes.Dword);
                pck.Add(this.astCtxt.bvsub(
                               this.astCtxt.extract(high, low, op1),
                               this.astCtxt.extract(high, low, op2))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPSUBD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpsubq_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Qword; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Qword);
                uint low = (dst.BitSize - BitSizes.Qword) - (index * BitSizes.Qword);
                pck.Add(this.astCtxt.bvsub(
                               this.astCtxt.extract(high, low, op1),
                               this.astCtxt.extract(high, low, op2))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPSUBQ operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpsubw_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            List<AbstractNode> pck = new List<AbstractNode>();

            for (uint index = 0; index < dst.Size / ByteSizes.Word; index++)
            {
                uint high = (dst.BitSize - 1) - (index * BitSizes.Word);
                uint low = (dst.BitSize - BitSizes.Word) - (index * BitSizes.Word);
                pck.Add(this.astCtxt.bvsub(
                               this.astCtxt.extract(high, low, op1),
                               this.astCtxt.extract(high, low, op2))
                             );
            }

            var node = this.astCtxt.concat(pck);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPSUBW operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vptest_s(Instruction inst)
        {
            var src1 = inst.Operands[0];
            var src2 = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            var node1 = this.astCtxt.bvand(op1, op2);
            var node2 = this.astCtxt.bvand(op1, this.astCtxt.bvnot(op2));

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node1, "VPTEST operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicExpression(inst, node2, "VPTEST operation");


            /* Update symbolic flags */
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF), "Clears adjust flag");
            this.cfPtest_s(inst, expr2, src1, true);
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Clears overflow flag");
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_PF), "Clears parity flag");
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_SF), "Clears sign flag");
            this.zf_s(inst, expr1, src1, true);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vpxor_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op2 = this.astBuilder.GetOperandAst(inst, src1);
            var op3 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            var node = this.astCtxt.bvxor(op2, op3);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VPXOR operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void vxorps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src1 = inst.Operands[1];
            var src2 = inst.Operands[2];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, src1);
            var op2 = this.astBuilder.GetOperandAst(inst, src2);

            /* Create the semantics */
            var node = this.astCtxt.bvxor(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "VXORPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void wait_s(Instruction inst)
        {
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void wbinvd_s(Instruction inst)
        {
            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void xadd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node1 = op2;
            var node2 = op1;

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "XCHG operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, src, "XCHG operation");


            /* Create symbolic operands */
            op1 = this.astBuilder.GetOperandAst(inst, dst);
            op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node3 = this.astCtxt.bvadd(op1, op2);

            /* Create symbolic expression */
            var expr3 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node3, dst, "ADD operation");


            /* Update symbolic flags */
            this.af_s(inst, expr3, dst, op1, op2);
            this.cfAdd_s(inst, expr3, dst, op1, op2);
            this.ofAdd_s(inst, expr3, dst, op1, op2);
            this.pf_s(inst, expr3, dst);
            this.sf_s(inst, expr3, dst);
            this.zf_s(inst, expr3, dst);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void xchg_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node1 = op2;
            var node2 = op1;

            /* Create symbolic expression */
            var expr1 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node1, dst, "XCHG operation");
            var expr2 = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node2, src, "XCHG operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void xor_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvxor(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "XOR operation");


            /* Update symbolic flags */
            this.undefined_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_AF));
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_CF), "Clears carry flag");
            this.clearFlag_s(inst, this.architecture.GetRegister(register_e.ID_REG_X86_OF), "Clears overflow flag");
            this.pf_s(inst, expr, dst);
            this.sf_s(inst, expr, dst);
            this.zf_s(inst, expr, dst);

            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void xorpd_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvxor(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "XORPD operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }


        void xorps_s(Instruction inst)
        {
            var dst = inst.Operands[0];
            var src = inst.Operands[1];

            /* Create symbolic operands */
            var op1 = this.astBuilder.GetOperandAst(inst, dst);
            var op2 = this.astBuilder.GetOperandAst(inst, src);

            /* Create the semantics */
            var node = this.astCtxt.bvxor(op1, op2);

            /* Create symbolic expression */
            var expr = this.ExpressionDatabase.StoreSymbolicAssignment(inst, node, dst, "XORPS operation");


            /* Update the symbolic control flow */
            this.controlFlow_s(inst);
        }
    }
}
