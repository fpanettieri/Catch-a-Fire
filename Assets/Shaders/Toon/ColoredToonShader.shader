Shader "Toon/Color"
{
	Properties
	{
		_Color ("Color", Color) = (1, 1, 1, 1)
		_Ramp ("Shading Ramp", 2D) = "gray" {}
	}
	
	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		CGPROGRAM
		#pragma surface surf Ramp
		
		sampler2D _Ramp;
		
		half4 LightingRamp (SurfaceOutput s, half3 lightDir, half atten)
		{
		  half NdotL = dot (s.Normal, lightDir);
		  half diff = NdotL * 0.5 + 0.5;
		  half3 ramp = tex2D (_Ramp, float2(diff)).rgb;
		  half4 c;
		  c.rgb = s.Albedo * _LightColor0.rgb * ramp * (atten * 2);
		  c.a = s.Alpha;
		  return c;
		}
		
		struct Input
		{
			float2 _Color;
		};
		
		fixed4 _Color;
		void surf (Input IN, inout SurfaceOutput o)
		{
			o.Albedo = _Color.rgb;
		}
		ENDCG
	}
	Fallback "Diffuse"
}
