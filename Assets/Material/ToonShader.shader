Shader "Custom/ToonShader" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_RampTex("Ramp", 2D) = "white" {}
		_CellShadingLevel("Cell Shading Level", Range(0,100)) = 3
		_Intensity("Intensity", Range(-2,2)) = 0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM

		#pragma surface surf Toon
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _RampTex;
		float4 _Color;
		float _CellShadingLevel;
		float _Intensity;

		struct Input {
			float2 uv_MainTex;
			float4 screenPos;
			float3 worldPos;
		};

		UNITY_INSTANCING_BUFFER_START(Props)
		UNITY_INSTANCING_BUFFER_END(Props)

		half4 LightingToon(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
		{
			float NdotL = dot(s.Normal, lightDir);
			float NdotV = dot(s.Normal, viewDir);

			float cel;

			if (_CellShadingLevel <= 0)
				cel = tex2D(_RampTex, fixed2(NdotL, 0.5));
			else
				cel = floor(NdotL * _CellShadingLevel) / (_CellShadingLevel - _Intensity);

			float4 color;

			color.rgb = s.Albedo * _LightColor0.rgb * cel * atten;

			//if (NdotL <= 0.4)
			//	color.rgb = -1;

			color.a = s.Alpha;

			return color;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);

			float dist = distance(_WorldSpaceCameraPos, IN.worldPos);

			o.Albedo = c * _Color.rgb;
			o.Alpha = c.a * _Color.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
