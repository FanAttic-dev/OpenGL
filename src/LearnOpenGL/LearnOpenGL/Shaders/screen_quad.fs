#version 430 core
out vec4 FragColor;

in vec2 TexCoords;

#define KERNEL_SIZE 9

uniform sampler2D screenTexture;

const float offset = 1.0 / 300.0;

void main()
{
	vec2 offsets[KERNEL_SIZE] = vec2[](
		vec2(-offset, offset),
		vec2(0, offset),
		vec2(offset, offset),
		vec2(-offset, 0),
		vec2(0, 0),
		vec2(offset, 0),
		vec2(-offset, -offset),
		vec2(0, -offset),
		vec2(offset, -offset)
	);

	float kernel[9] = float[](
		1, 1, 1,
		1, -8, 1,
		1, 1, 1
	);

	float kernel_sum = 1.0;

	vec3 color = vec3(0.0);
	for (int i = 0; i < KERNEL_SIZE; ++i)
	{
		color += (kernel[i] / kernel_sum) * texture(screenTexture, TexCoords.st + offsets[i]).rgb;
	}

	FragColor = vec4(color, 1.0);
	
}