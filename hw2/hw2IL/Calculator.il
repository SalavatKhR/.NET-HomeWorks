.class public abstract auto ansi sealed beforefieldinit hw2IL.Calculalator
  extends System.Object
{
  .method public hidebysig static float64 Calculate(float64 val1, string operation, float64 val2) cil managed
  {
    .maxstack 2
    
    ldarg.1
    ldstr "+"
    call bool System.String::op_Equality(string, string)
    brtrue.s ILL_ADD
    
    ldarg.1
    ldstr "-"
    call bool System.String::op_Equality(string, string)
    brtrue.s ILL_SUB
    
    ldarg.1
    ldstr "*"
    call bool System.String::op_Equality(string, string)
    brtrue.s ILL_MUL
    
    ldarg.1
    ldstr "/"
    call bool System.String::op_Equality(string, string)
    brtrue.s ILL_DIV
    
    ldc.i4.0 ret
    
    ILL_ADD: ldarg.0 ldarg.2 add ret
    
    ILL_SUB: ldarg.0 ldarg.2 sub ret
    
    ILL_MUL: ldarg.0  ldarg.2 mul ret
            
    ILL_DIV: ldarg.0 ldarg.2 div ret
  }
}