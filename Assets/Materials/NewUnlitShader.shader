Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NormalMap("Normal map", 2D) = "bump" {}
        _alpha("Alpha", range(0,1)) = 1
    }
    SubShader
    {
        Tags {"RenderType" = "Transparent" "Queue" = "Transparent" "IgnoreProjector" = "True"}
        LOD 100

        Pass
        {
            ZWrite On
			ColorMask 0	
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
            
            CGPROGRAM
            #pragma surface surf Lambert alpha
            struct Input
            {
                float2 uv_MainTex;
                float2 uv_BumpMap;
                float3 viewDir;
            };

            sampler2D _MainTex;
            sampler2D _ambient;
            sampler2D _BumpMap;
            fixed _alpha;
            fixed _oclussion;
            float4 _Color;

            void surf(Input IN, inout SurfaceOutput o)
            {
                o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _Color.rgb * lerp(1, tex2D(_ambient, IN.uv_MainTex).rgb, _oclussion);
                o.Alpha = _alpha;
                //o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
                //half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
            }
            ENDCG
        }
    }
}
