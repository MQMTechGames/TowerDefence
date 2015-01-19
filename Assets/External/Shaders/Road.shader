Shader "mqmtech/road" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SecondTex ("Second (RGB)", 2D) = "white" {}
		_Mask ("Mask (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _SecondTex;
		sampler2D _Mask;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			half4 c2 = tex2D (_SecondTex, IN.uv_MainTex);
			half4 m = tex2D (_Mask, IN.uv_MainTex);
			
			//o.Albedo = lerp(c.rgb, c2.rgb, m.a);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
