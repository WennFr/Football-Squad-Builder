import { Club } from '../types';

const URL = 'https://localhost:7216/api/FootballData';

export const fetchClubs = async (competitionId: string): Promise<Club[]> => {
    try {
      const response = await fetch(`${URL}/Clubs/${competitionId}`);
      if (!response.ok) {
        throw new Error(`Network response was not ok: ${response.statusText}`);
      }
      const data: Club[] = await response.json();
      return data;
    } catch (error) {
      console.error('Error fetching clubs:', error);
      throw error; 
    }
  };