# GE-CA
Repo for Games Engines CA


## Project Proposal

For my Games Engines Project I plan to make an audio visualizer in the form of a tunnel where there are cuboid going around the inside of
the tunnel which grow and shrink according to the audio. The direction of the tunnel will be procedurally generated as well as the colours
of the different bars. The camera will move throught this tunnel as the it changes direction and the song is played.

It will have a similar concept to this project:
[Mesh Vertices](https://www.youtube.com/watch?v=MXm9OmzRe2o&list=PL1n0B6z4e_E5qaYwUOlJ63XI2OR9ty7Bs).

where the camera moves through a procedually generated tunnel but will differ in that it will have an audio visualiser that controls the 
movement of objects inside the tunnel around the camera as it moves as well as differeing colours of these objects.

There are many Tutorials of audio visualisation in available for as it is a somewhat popular project Unity that I will use to help me
learn the basics . There is Unity documentation
available on this subject using [AudioSource.GetSpectrumData](https://docs.unity3d.com/ScriptReference/AudioSource.GetSpectrumData.html).
This allows you to grab the audio spectrym data on each update. You can use this data to get teh audio info (volume at each pitch).




================================================================================================================================

## Project Development

The first part that I started for the development of the project was to generate one segment of the tunnel that the camera would
move through. To do this I created a cube prefab that would then be instansiated as part of the one ring or segment. The number
of cubes that would make a ring without any overlap and with a relatively small distance between them came to 64, so each ring 
s made of 64 cubes. Then a for loop runs 64 times to generate one ring.

The transform of the main camera is  used as the center point for each ring. The ring generation for loop is then nested inside
another for loop that generates the rest of the rings to make up the tunnel of segments, the position of the camera is taken and
the z value is increased in each for loop to generate the one ring in front of the next. Each ring is coloured differently and
uses a Mathf.PingPong function to go back and fourth between colours of the raindbow. All genereated cubes are added to a 2D
array called rings that is later used to manipulate them with the values from the audio data.

All of the Cube and ring generation is in a function called MakeRing() that is invokedRepeating() immedietly and every 0.15
seconds. There is also a script that is a component of every cube prefab that destroys it after 3.2 seconds as by this time that
cube will be out of view and only takeing up resources.

Next I worked on the camera movement. To begin I just wanted to make the camera simply move forward through the generated rings.
This was done with in the Update() function of the CameraMovement Script by taking the transform.position of the camera
increasing the Z value by 5 and then lerping to that position at a speed that was not jarring to the viewer and was slow enough
so that it stayed behind the rings that were yet to be generated. There was plans to have the camera move on the x and y axes as
mentions in the proposal above but this proved to be difficult to implement and adapt the current generation to within the time
constraints of the assignment.

The next stage of the project was to implement the audio visualiser. I learnt from this tutorial:

[![tutorial video](http://img.youtube.com/vi/5pmoP1ZOoNs/0.jpg)](http://www.youtube.com/watch?v=5pmoP1ZOoNs)

It was fairly long in many dfifferent parts but very helpful in the development of the project.
From this tutorial I made the getAudioData script. As the name implies this script gets the samples from the set audio source, a public float array of size 512 is created as we are getting 512 samples from the audio source.
In the Start() function GetComponent<AudioSource> is used then in Update() a function called GetSpectrumAudioSource() is called. 
This is where GetSpectrumdata() is used on the audioSource object to get the values and store them in a float array. Later a 
Function called MakeFrequencyBands() was added that is also called in the Update() function. The aim of this was take 512 and
split it into 8 usable frequency bands as opposed to the larger 512 where there is only change in value at some parts of the
samples. With 8 bands the visualisation of the values would look better but this approach ended up not entirely working either
so the regular 512 samples are used.
  
These samples are applied to the cubes of each ring back in the spawnCubes script in the Update() function there is a set of nested for loops that iterate through each cube and ring that are in the rings array and use transform.localscale to apply the samples from getAudioData to them those values are also multiplyed by and added to by a maxScale to increase to they look when visualised.

## Video of Project

[![Project Video](http://img.youtube.com/vi/ndvFuHCM0vs/0.jpg)](http://www.youtube.com/watch?v=ndvFuHCM0vs)



