void DemenderTaille(out int nbLignes, out int nbColonnes)
{
    Console.Write("Entrez le nombre de lignes :");
     string ligne=Console.ReadLine();
     bool estNombre = int.TryParse(ligne, out nbLignes);

          while (!estNombre&&nbLignes<=0 || nbLignes>80)
        {
            Console.Write("Entrez le nombre de lignes :");
            ligne=Console.ReadLine();
            estNombre = int.TryParse(ligne, out nbLignes);
        }
   
    Console.Write("Entrez le nombre de colonnes :");
    string colonne=Console.ReadLine();
    bool estNombre2 = int.TryParse(colonne, out nbColonnes);
    
        while (!estNombre2&&nbColonnes<=0 || nbColonnes>80)
        {
            Console.Write("Entrez le nombre de colonnes :");
            colonne=Console.ReadLine();
            estNombre2 = int.TryParse(colonne, out nbColonnes);
        }
  


}

void RemplirVille(long[,] ville)
{
   
    for (int i = 0; i < ville.GetLength(0); i++)
    {
        for (int j = 0; j < ville.GetLength(1); j++)
        {
            ville[i, j] = 1000;
        }
    }
}

void AfficherVille(long[,] ville)
{
    for(int i = 0; i < ville.GetLength(0); i++)
    {
        for(int j = 0; j < ville.GetLength(1); j++)
        {
            if (ville[i, j] >= 0 && ville[i, j] <= 1000)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
            }
            else if (ville[i, j] >= 1001 && ville[i, j] <= 2000)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write(" ");
            }
            else if (ville[i, j] >= 2001 && ville[i, j] <= 3000)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(" ");
            }
            else if (ville[i, j] >= 3001 && ville[i, j] <= 4000)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write(" ");
            }
            else if (ville[i, j] >= 4001 && ville[i, j] <= 5000)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(" ");
            }
            else if (ville[i, j] >= 5001 && ville[i, j] <= 6000)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write(" ");
            }
            else if (ville[i, j] >= 6001 && ville[i, j] <= 7000)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
            }
            else if (ville[i, j] >= 7001 && ville[i, j] <= 8000)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(" ");
            }
            else if (ville[i, j] >= 8001 && ville[i, j] <= 9000)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" ");
            }
            else if (ville[i, j] >= 9001)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write(" ");
            }
            Console.ResetColor();
        
        }
        Console.WriteLine();
    }
}

void FaireGrandirVille(long[,] ville, (int, int) position)
{
    Random rnd = new Random();
    for (int i = position.Item1 - 4; i <= position.Item1 + 4; i++)
    {
        for (int j = position.Item2 - 4; j <= position.Item2 + 4; j++)
        {
            if (i >= 0 && i < ville.GetLength(0) && j >= 0 && j < ville.GetLength(1))
            {               
                ville[i, j] =ville[i,j]*new Random().NextInt64(1,4);
          
            }
        }
     
    }

}

(int,int) ObtenirPositionPopulationBasse(long[,] ville )
{
    int positionLigne;
    int positionColonne;
    positionLigne = 0;
    positionColonne = 0;
    long populationBasse = ville[0, 0];
    for (int i = 0; i < ville.GetLength(0); i++)
    {
        for (int j = 0; j < ville.GetLength(1); j++)
        {
            if (ville[i, j] < populationBasse)
            {
                populationBasse = ville[i, j];
                positionLigne = i;
                positionColonne = j;
            }
        }
    }
    return (positionLigne, positionColonne);
}


(int, int) Position;
DemenderTaille(out Position.Item1, out Position.Item2);
long[,]maVille = new long[Position.Item1, Position.Item2];
RemplirVille(maVille);
for (int i = 0; i <= 100; i++)
{
    Console.WriteLine("Itération " + i);  
    (int, int) nombreAleatoire;
    nombreAleatoire.Item1 = new Random().Next(0, Position.Item1);
    nombreAleatoire.Item2 = new Random().Next(0, Position.Item2);
    FaireGrandirVille(maVille, nombreAleatoire);
    AfficherVille(maVille);

}
Console.WriteLine("La position de la population la plus basse est : " + ObtenirPositionPopulationBasse(maVille));


