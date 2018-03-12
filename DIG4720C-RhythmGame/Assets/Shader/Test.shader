Shader "Pat/Toon"
{
    Properties
    {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Texture", 2D) = "white" {}
		_DisolveTex("Disolve Texture", 2D) = "white" {}
		_DisolveHeight("Height of Effect", Float) = 0
		_DisolveSize("size of effect", Float) = 2
		_DisolveStart("Start Height of Effect", Float) = 3

		_ExtrudeAmt("ExtA", float) = 1
		_ShadowI("Shadow Intensity", float) = 10
		_TimeSize("SizeOverTime", float) = 0
		 _SizeSpeed("Pulse Rate", float) = 0.1
    }
    SubShader
    {
        Pass
        {
            Tags {"LightMode"="ForwardBase"}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            #pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight
            #include "AutoLight.cginc"

            struct v2f
            {
                float2 uv : TEXCOORD0;
				float2 worldPos : TEXCOORD2;
                SHADOW_COORDS(1) // put shadows data into TEXCOORD1
                fixed3 diff : COLOR0;
                fixed3 ambient : COLOR1;
                float4 pos : SV_POSITION;
            };


			float4 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _DisolveTex;
			float _DisolveHeight;
			float _DisolveSize;
			float _DisolveStart;
			float _ExtrudeAmt;
			float _ShadowI;
			float _TimeSize;
			float _SizeSpeed;
            v2f vert (appdata_base v)
            {
                v2f o;

				if( _TimeSize == 0)
				{
				v.vertex.xyz += v.normal.xyz * _ExtrudeAmt; //* sin(_Time.y);
				}
				else
				{
				v.vertex.xyz += v.normal.xyz * _ExtrudeAmt * sin(_Time.y/_SizeSpeed);
				//_Color += Color(1,0,0,1) * sin(_Time.y/_SizeSpeed);
				}

                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                half3 worldNormal = UnityObjectToWorldNormal(v.normal);
                half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
                o.diff = nl* _ShadowI * _LightColor0.rgb;
                o.ambient = ShadeSH9(half4(worldNormal,1));
				o.worldPos = .01 * mul(unity_ObjectToWorld, v.vertex).xyz;
                TRANSFER_SHADOW(o)
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
			
				float transition = _DisolveHeight - i.worldPos.y;
				clip(_DisolveStart + (transition + (tex2D(_DisolveTex, i.uv)) * _DisolveSize));

                fixed4 col = tex2D(_MainTex, i.uv);

                fixed shadow = SHADOW_ATTENUATION(i);
                fixed3 lighting = i.diff * shadow + i.ambient;
                col.rgb *= lighting * _Color;
                return col;
            }
            ENDCG
        }
        UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
    }
}