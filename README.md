Welcome to the PathFindingProject!

Initially it was planned to be as it is called a path finding project, but throughout a little jhourney I was creating path finding scripts, I learned how to use Debug.DrawLine() function and started vbisualising various mathematical and geometrical things using this function.


My project contains these scripts:
- Area_Calculator.cs
- Circle_Controller.cs
- Pathfinder_1.cs
- Pathfinder_2.cs
- Pathfinder_3.cs
- Triangle_Controller.cs


More description about each script:

Area_Calculator.cs
- Will always visualise the biggest possible are with given perimeter. (Note that the perimeter you give script should be hlaf of actual perimeter)
- By changing value x you will create your own rectangle which perimeter is always static and connected to the "perimeter" variable.

Circle_Controller.cs
- Can be also concidered as cone conroller because there are some bugs I need to fix but until then by changing "center" vector you can create a cone.
- By changing "subdivision_count" variable you can add as it is called resolution to your circle or cone.
- Because all subdivisions you add to your circle are automaticly visualised I added "show_subdivisions" variable in case you would like to make your circle or cone clear.
- You can also adjist "radius" variable to make your shape bigger or smaller.
- Read only variable "area" is calculated in real time using this formula (S = PI * radius^2)

Pathfinder_1.cs



Pathfinder_2.cs


Pathfinder_3.cs



Triangle_Controller.cs
