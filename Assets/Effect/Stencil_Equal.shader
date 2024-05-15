Shader "Custom/NewSurfaceShader"
{
    Properties
    {
      [IntRange] _StencilID ("Stencil ID", Range(0,255)) = 0
      _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags 
    {
     "RenderType"="Opaque"
     "RenderPipeline" = "UniversalPipeline"
     "Queue" = "Geometry"
     }
     Pass{
        
        Blend Zero One
        ZWrite Off

        // Stencil
        // {
        //     Ref [_StencilID]
        //     Comp Always
        //     Pass Replace
        //     Fail Keep
        // }
     }
    
    }
   
}
