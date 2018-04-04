Shader "Pat/PatsTexAnim"
{
	Properties
	{
		_MainTex ("Background", 2D) = "white" {}
		_Overlay1 ("Overlay 1", 2D) = "white" {}
		_Alpha("Overlay Alpha", float) = 1
		_Overlay2 ("Overlay 2", 2D) = "white" {}
		_Alpha2("Overlay2 Alpha", float) = 1

	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
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
				float2 uv2 : TEXCOORD1;
				float2 uv3 : TEXCOORD2;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
				float2 uv3 : TEXCOORD2;

				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _Overlay1;
			sampler2D _Overlay2;
			float4 _Overlay1_ST;
			float4 _Overlay2_ST;
			float _Alpha;
			float _Alpha2;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv2 = TRANSFORM_TEX(v.uv, _Overlay1);
				o.uv3 = TRANSFORM_TEX(v.uv, _Overlay2);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = lerp(tex2D(_MainTex, i.uv), tex2D(_Overlay1, i.uv2), _Alpha);
				col *= lerp(tex2D(_MainTex, i.uv), tex2D(_Overlay2, i.uv3), _Alpha2);
				return col;
			}
			ENDCG
		}
	}
}
