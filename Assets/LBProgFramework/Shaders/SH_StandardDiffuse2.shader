Shader "LBProgramming/ColorDiffuse" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_AmbientColor("AmbientColor Color", Color) = (1,1,1,1)
		_MySliderValue("This is a slider", Range(0,10)) = 2.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0


		struct Input {
			float2 uv_MainTex;
		};

		fixed4 _Color;
		float4 _AmbientColor;
		float _MySliderValue;
		void surf (Input IN, inout SurfaceOutputStandard o) {
		    //The shader will now take it's Color from The Color property
		    fixed4 c = pow((_Color + _AmbientColor), _MySliderValue);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
