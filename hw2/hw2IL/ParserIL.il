.class public abstract sealed auto ansi beforefieldinit
  hw2.ParserIl
    extends [System.Runtime]System.Object
{

  .class nested private sealed auto ansi serializable beforefieldinit
    '<>c'
      extends [System.Runtime]System.Object
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )

    .field public static initonly class hw2.ParserIl/'<>c' '<>9'

    .field public static class [System.Runtime]System.Func`3<string, string, string> '<>9__1_0'

    .method private hidebysig static specialname rtspecialname void
      .cctor() cil managed
    {
      .maxstack 8

      IL_0000: newobj       instance void hw2.ParserIl/'<>c'::.ctor()
      IL_0005: stsfld       class hw2.ParserIl/'<>c' hw2.ParserIl/'<>c'::'<>9'
      IL_000a: ret

    } 

    .method public hidebysig specialname rtspecialname instance void
      .ctor() cil managed
    {
      .maxstack 8

      IL_0000: ldarg.0      
      IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
      IL_0006: nop
      IL_0007: ret

    }

    .method assembly hidebysig instance string
      '<TryParseArguments>b__1_0'(
        string c,
        string n
      ) cil managed
    {
      .maxstack 8

      
      IL_0000: ldarg.1      
      IL_0001: ldstr        " "
      IL_0006: ldarg.2      
      IL_0007: call         string [System.Runtime]System.String::Concat(string, string, string)
      IL_000c: ret

    } 
  }

  .field private static initonly string[] SupportedOperations

  .method public hidebysig static int32
    TryParseArguments(
      string[] args,
      [out] float64& val1,
      [out] string& operation,
      [out] float64& val2
    ) cil managed
  {
    .maxstack 6
    .locals init (
      [0] bool isVal1Int,
      [1] bool isVal2Int,
      [2] bool V_2,
      [3] int32 V_3,
      [4] bool V_4,
      [5] bool V_5
    )

    
    IL_0000: nop

    
    IL_0001: ldarg.0      
    IL_0002: ldc.i4.0
    IL_0003: ldelem.ref
    IL_0004: ldarg.1      
    IL_0005: call         bool [System.Runtime]System.Double::TryParse(string, float64&)
    IL_000a: stloc.0      

    
    IL_000b: ldarg.2      
    IL_000c: ldarg.0      
    IL_000d: ldc.i4.1
    IL_000e: ldelem.ref
    IL_000f: stind.ref

    
    IL_0010: ldarg.0      
    IL_0011: ldc.i4.2
    IL_0012: ldelem.ref
    IL_0013: ldarg.3      
    IL_0014: call         bool [System.Runtime]System.Double::TryParse(string, float64&)
    IL_0019: stloc.1      

    
    IL_001a: ldloc.0      
    IL_001b: brfalse.s    IL_0023
    IL_001d: ldloc.1      
    IL_001e: ldc.i4.0
    IL_001f: ceq
    IL_0021: br.s         IL_0024
    IL_0023: ldc.i4.1
    IL_0024: stloc.2      

    IL_0025: ldloc.2      
    IL_0026: brfalse.s    IL_0049

    
    IL_0028: nop

    
    IL_0029: ldarg.0      
    IL_002a: ldc.i4.0
    IL_002b: ldelem.ref
    IL_002c: ldarg.0      
    IL_002d: ldc.i4.1
    IL_002e: ldelem.ref
    IL_002f: ldarg.0      
    IL_0030: ldc.i4.2
    IL_0031: ldelem.ref
    IL_0032: ldstr        " is not a valid calculation syntax"
    IL_0037: call         string [System.Runtime]System.String::Concat(string, string, string, string)
    IL_003c: call         void [System.Console]System.Console::WriteLine(string)
    IL_0041: nop


    IL_0042: ldc.i4.1
    IL_0043: stloc.3      
    IL_0044: br           IL_0101


    IL_0049: ldsfld       string[] hw2.ParserIl::SupportedOperations
    IL_004e: ldarg.2      
    IL_004f: ldind.ref
    IL_0050: call         bool [System.Linq]System.Linq.Enumerable::Contains<string>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0/*string*/>, !!0/*string*/)
    IL_0055: ldc.i4.0
    IL_0056: ceq
    IL_0058: stloc.s      V_4

    IL_005a: ldloc.s      V_4
    IL_005c: brfalse.s    IL_00ba

    
    IL_005e: nop

    
    IL_005f: ldc.i4.5
    IL_0060: newarr       [System.Runtime]System.String
    IL_0065: dup
    IL_0066: ldc.i4.0
    IL_0067: ldarg.0      
    IL_0068: ldc.i4.0
    IL_0069: ldelem.ref
    IL_006a: stelem.ref
    IL_006b: dup
    IL_006c: ldc.i4.1
    IL_006d: ldarg.0     
    IL_006e: ldc.i4.1
    IL_006f: ldelem.ref
    IL_0070: stelem.ref
    IL_0071: dup
    IL_0072: ldc.i4.2
    IL_0073: ldarg.0      
    IL_0074: ldc.i4.2
    IL_0075: ldelem.ref
    IL_0076: stelem.ref
    IL_0077: dup
    IL_0078: ldc.i4.3
    IL_0079: ldstr        " is not a valid calculation syntax. Supported operations are "
    IL_007e: stelem.ref
    IL_007f: dup
    IL_0080: ldc.i4.4
    IL_0081: ldsfld       string[] hw2.ParserIl::SupportedOperations
    IL_0086: ldsfld       class [System.Runtime]System.Func`3<string, string, string> hw2.ParserIl/'<>c'::'<>9__1_0'
    IL_008b: dup
    IL_008c: brtrue.s     IL_00a5
    IL_008e: pop
    IL_008f: ldsfld       class hw2.ParserIl/'<>c' hw2.ParserIl/'<>c'::'<>9'
    IL_0094: ldftn        instance string hw2.ParserIl/'<>c'::'<TryParseArguments>b__1_0'(string, string)
    IL_009a: newobj       instance void class [System.Runtime]System.Func`3<string, string, string>::.ctor(object, native int)
    IL_009f: dup
    IL_00a0: stsfld       class [System.Runtime]System.Func`3<string, string, string> hw2.ParserIl/'<>c'::'<>9__1_0'
    IL_00a5: call         !!0/*string*/ [System.Linq]System.Linq.Enumerable::Aggregate<string>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0/*string*/>, class [System.Runtime]System.Func`3<!!0/*string*/, !!0/*string*/, !!0/*string*/>)
    IL_00aa: stelem.ref
    IL_00ab: call         string [System.Runtime]System.String::Concat(string[])
    IL_00b0: call         void [System.Console]System.Console::WriteLine(string)
    IL_00b5: nop

   
    IL_00b6: ldc.i4.2
    IL_00b7: stloc.3      
    IL_00b8: br.s         IL_0101

    
    IL_00ba: ldarg.0      
    IL_00bb: ldc.i4.1
    IL_00bc: ldelem.ref
    IL_00bd: ldstr        "/"
    IL_00c2: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_00c7: brfalse.s    IL_00d8
    IL_00c9: ldarg.0      
    IL_00ca: ldc.i4.2
    IL_00cb: ldelem.ref
    IL_00cc: ldstr        "0"
    IL_00d1: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_00d6: br.s         IL_00d9
    IL_00d8: ldc.i4.0
    IL_00d9: stloc.s      V_5

    IL_00db: ldloc.s      V_5
    IL_00dd: brfalse.s    IL_00fd

    
    IL_00df: nop

    
    IL_00e0: ldarg.0      
    IL_00e1: ldc.i4.0
    IL_00e2: ldelem.ref
    IL_00e3: ldarg.0      
    IL_00e4: ldc.i4.1
    IL_00e5: ldelem.ref
    IL_00e6: ldarg.0      
    IL_00e7: ldc.i4.2
    IL_00e8: ldelem.ref
    IL_00e9: ldstr        " - divide by zero"
    IL_00ee: call         string [System.Runtime]System.String::Concat(string, string, string, string)
    IL_00f3: call         void [System.Console]System.Console::WriteLine(string)
    IL_00f8: nop

    // [39 17 - 39 26]
    IL_00f9: ldc.i4.3
    IL_00fa: stloc.3      // V_3
    IL_00fb: br.s         IL_0101

    // [42 13 - 42 22]
    IL_00fd: ldc.i4.0
    IL_00fe: stloc.3      // V_3
    IL_00ff: br.s         IL_0101

    // [43 9 - 43 10]
    IL_0101: ldloc.3      // V_3
    IL_0102: ret

  } // end of method ParserIl::TryParseArguments

  .method private hidebysig static specialname rtspecialname void
    .cctor() cil managed
  {
    .maxstack 8

    
    IL_0000: ldc.i4.4
    IL_0001: newarr       [System.Runtime]System.String
    IL_0006: dup
    IL_0007: ldc.i4.0
    IL_0008: ldstr        "+"
    IL_000d: stelem.ref
    IL_000e: dup
    IL_000f: ldc.i4.1
    IL_0010: ldstr        "-"
    IL_0015: stelem.ref
    IL_0016: dup
    IL_0017: ldc.i4.2
    IL_0018: ldstr        "*"
    IL_001d: stelem.ref
    IL_001e: dup
    IL_001f: ldc.i4.3
    IL_0020: ldstr        "/"
    IL_0025: stelem.ref
    IL_0026: stsfld       string[] hw2.ParserIl::SupportedOperations
    IL_002b: ret

  } 
} 
