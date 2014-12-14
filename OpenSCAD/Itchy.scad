
//$fn=100;
$fs = 0.01;

module ItchyBase()
{

difference() 
{	
union(){
difference() 
{	
	intersection()
	{
		union()
		{
			difference() 
			{	
				translate([0, 0, 10])
					cylinder(h = 20, r = 21.5, center=true);

				translate([0, 0, 15+4])
					cylinder(h = 30, r1 = 21.5-5, r2 = 21.5-1, center=true);
			}

			translate([0, 0, 15+2])
				cylinder(h = 30, r1 = 6+2+4, r2 = 6+2, center=true);

			// Stege
			for (i = [0,60,120])
				rotate([0,0,i+30])
					cube ([42,2.5,64], center=true);

			// Verstärkungen für Madenschrauben
			for (k = [90])
				rotate([0,0,k])
					translate([0, 0, 4])rotate([0,90,0])
						cylinder(h = 80, r = 5, center=true);

	
		}

	translate([0, 0, 16])
		cylinder(h = 32, r1 = 6+2+35, r2 = 6+2, center=true);

	cylinder(h = 64, r = 21.5, center=true);


	}

	// Loch für Linearkugellager
	cylinder(h = 80, r = 6, center=true);

	// Löcher für Federn
	for (j = [-14,14])
		translate([j, 0, 0])
			cylinder(h = 40, r = 4.1, center=true);

	

}

intersection()
	{
	for (k = [0,180]) rotate([0,0,k]){
			translate([14, 0, 4])
			//rotate([0,90,0])

			for (j = [90,-90]) rotate([0,j,0]){
				translate([0, 0, -5.75])
					cylinder(h = 5, r1 = 3+5, r2 = 3);
				//translate([0, 0, -4.5])
				//	cylinder(h = 2, r1 = 2+2, r2 = 3+2);
			}
	}
	cylinder(h = 32, r = 21.5);
	}
}
	// Löcher für Madenschrauben
	for (k = [0,90])
		rotate([0,0,k])
		translate([0, 0, 4])rotate([45,0,0])
			#cube ([50,3.3,3.3], center=true);

}

}

module ItchyCarrige()
	{
	difference()
		{
	
	union(){
		for (k = [0,180])
		translate([0, 0, 3])
		rotate([0,90,k])
		difference()
		{
			
			union(){
				translate([0, 0, 11.25])
					cylinder(h = 2, r1 = 2+3, r2 = 3);
	
				cylinder(h = 11.25, r = 2+3);
				}
	
			rotate([45,90,0])
				#cube ([35,3.3,3.3], center=true);
		}
	
		cylinder(h = 8, r = 5+2);
	}
	translate([0, 0, 3])
	cylinder(h = 10, r = 5);
	
	translate([0, 0, -10])
	cube ([50,50,20], center=true);
	
	translate([0, 0, 8-2.5])
	rotate([90,0,0])
	#cylinder(h = 20, r = 1.6, center=true);
	
	cylinder(h = 30, r = 3.1, center=true);

translate([0, 0, 3])
rotate([45,00,0])
				#cube ([35,3.3,3.3], center=true);			
	}
	
}


module Spring(height){

linear_extrude(height = height, twist = 360*height/2)
//rotate_extrude(5*360, translate=[0,80]) 
translate([2.5, 0, 0])
//rotate([40,0,0])
			circle(0.5);
}

*union(){
    cylinder(r=20, h=80);
    rotate_extrude(5*360, translate=[0,80])
         translate([20,0])
                square([14,5], center=true);
} 

module X()
{
//render(convexity = 2)
{
ItchyBase();
translate([0, 0, 80])rotate([180,00,0])
	ItchyCarrige();
}

%translate([0, 0, 60])
	cylinder(h = 160, r = 3, center=true);
color("silver")%#cylinder(h = 32, r = 6);
	// Federn
	%#for (j = [-14,14])
		translate([j, 0, 5])
			Spring(70);

//			cylinder(h = 70, r = 3);
%translate([0, 0, 32])
	cylinder(h = 5, r = 5);
}

X();

