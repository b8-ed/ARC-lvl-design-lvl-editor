Shader "LBProgramming/ScrollingEffect" {
	Properties {
	    _MainTint("Diffuse Tint", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_ScrollSpeedX("X Scroll Speed", Range(0,10)) = 2
		_ScrollSpeedY("Y Scroll Speed", Range(0,10)) = 2
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0
        
        fixed4 _MainTint;
        fixed _ScrollSpeedX;
        fixed _ScrollSpeedY;
		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed2 scrolledUV = IN.uv_MainTex;
			fixed xScrollValue = _ScrollSpeedX * _Time;
			fixed yScrollValue = _ScrollSpeedY * _Time;
			
			scrolledUV += fixed2(xScrollValue, yScrollValue);
			
			half4 c = tex2D(_MainTex, scrolledUV);
			o.Albedo = c.rgb * _MainTint;
			o.Alpha = c.a;
			
		}
		ENDCG
	}
	FallBack "Diffuse"
}
