// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Toon/Lit" {
	Properties {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {} 
		_DisolveTex("Disolve Texture", 2D) = "white" {}
		_DisolveHeight("Height of Effect", Float) = 0
		_DisolveSize("size of effect", Float) = 2
		_DisolveStart("Start Height of Effect", Float) = 8

		_DisplaceTex("displacment tex",2d) = "white" {}
		_Mag("Magnitude", range(0,0.005)) = 0

	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
CGPROGRAM
#pragma surface surf ToonRamp

sampler2D _Ramp;

// custom lighting function that uses a texture ramp based
// on angle between light direction and normal
#pragma lighting ToonRamp exclude_path:prepass
inline half4 LightingToonRamp (SurfaceOutput s, half3 lightDir, half atten)
{
	#ifndef USING_DIRECTIONAL_LIGHT
	lightDir = normalize(lightDir);
	#endif
	
	half d = dot (s.Normal, lightDir)*0.5 + 0.5;
	half3 ramp = tex2D (_Ramp, float2(d,d)).rgb;
	
	half4 c;
	c.rgb = s.Albedo * _LightColor0.rgb * ramp * (atten * 2);
	c.a = 0;
	return c;
}

sampler2D _MainTex;
float4 _Color;

struct Input {
	float2 uv_MainTex : TEXCOORD0;
};

void surf (Input IN, inout SurfaceOutput o) {
	half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	o.Albedo = c.rgb;
	o.Alpha = c.a;
}
ENDCG
        Tags { "RenderType"="Opaque" "LightMode" = "ForwardBase" }
		LOD 200

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float3 worldPos : TEXCOORD1;
			};
			float4 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _DisolveTex;
			float _DisolveHeight;
			float _DisolveSize;
			float _DisolveStart;
			sampler2D _DisplaceTex;
			float _Mag;
			
	//half d = dot (s.Normal, lightDir)*0.5 + 0.5;
	//half3 ramp = tex2D (_Ramp, float2(d,d)).rgb;
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
			float transition = _DisolveHeight - i.worldPos.y;
				clip(_DisolveStart + (transition + (tex2D(_DisolveTex, i.uv)) * _DisolveSize));
				// sample the texture

				float2 disp = tex2D(_DisplaceTex, i.uv).xy;
				disp = ((disp*2)-1)*(_Mag*sin(_Time.y));

				fixed4 col = tex2D(_MainTex, i.uv + disp)* _Color; 
			//fixed4 col = s.Albedo * _LightColor0.rgb * ramp * (atten * 2);
			//col *= float4(i.uv.x,i.uv.y,0,1);
			//col *= tex2D(_MainTex, i.uv);
				return col;
			}
			ENDCG
		}
	} 

	Fallback "Diffuse"
}
