import { Player } from '../types';

const URL = 'https://localhost:7216/api/FootballData';

export const fetchPlayers = async (clubId: string): Promise<Player[]> => {
    try {
      const response = await fetch(`${URL}/Players/${clubId}`);
      if (!response.ok) {
        throw new Error(`Network response was not ok: ${response.statusText}`);
      }
      const data: Player[] = await response.json();
      return data;
    } catch (error) {
      console.error('Error fetching clubs:', error);
      throw error; 
    }
  };