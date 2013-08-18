Shader "Unlit/TintedAlphaBlend" 
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color ("Color", Color) = (1.0, 1.0, 1.0, 1.0)
	}
	
	SubShader
	{
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        LOD 200
    
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha 

        Pass
        {
            Lighting Off
            SetTexture [_MainTex]
            { 
                constantColor[_Color]
                combine constant * texture
            } 
        }
    }
    
	FallBack "Diffuse"
}
