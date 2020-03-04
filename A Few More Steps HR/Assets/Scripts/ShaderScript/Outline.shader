Shader "Custom/Outline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _OutlineColour("OutlineColour",Color) = (0,0,0,1)
        _OutlineWidth("OutlineWidth", Range(1,5)) = 1
        _Colour("Main Color",Color) = (0.5,0.5,0.5,1)
    }

        CGINCLUDE
#include "UnityCG.cginc"
            struct appdata
        {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
        };
        struct v2f
        {
            float4 pos : POSITION;
            float3 normal : NORMAL;
        };
        float4 _OutlineColour;
        float _OutlineWidth;
        v2f vert(appdata v)
        {
            v.vertex.xyz *= _OutlineWidth;
            v2f o;
            o.pos = UnityObjectToClipPos(v.vertex);
            return o;
        }
     ENDCG

    SubShader
    {
       pass
       {
           ZWrite off
           CGPROGRAM
           #pragma vertex vert
           #pragma fragment frag
        half4 frag(v2f i) : COLOR
        {
           return _OutlineColour;
        }
        ENDCG
       }
     //normal pass
       pass
       {
        ZWrite On
        Material
        {
            Diffuse[_Colour]
            Ambient[_Colour]
        }
        Lighting On
        SetTexture[_MainTex]
        {
            ConstantColor[_Colour]
        }

        SetTexture[_MainTex]
        {
            Combine previous * primary DOUBLE
        }
       
       }
    }
}
