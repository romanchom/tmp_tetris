Shader "Custom/Fluff" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_EyeFuckGradinent("Base (RGB)", 2D) = "white" {}
		_Color ("Color", Color) = (1, 1, 1, 1)
	}
	SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent"}
		Blend SrcAlpha OneMinusSrcAlpha
		Cull Off
		ZWrite Off
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _EyeFuckGradinent;
		float4 _Color;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			half4 g = tex2D (_EyeFuckGradinent, IN.uv_MainTex + float2(0, -_Time.y));
			o.Emission = c.rgb * _Color * g;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
