import { Competition } from '../types';

const URL = 'https://localhost:7216/api/FootballData';

export const fetchCompetitions = async (): Promise<Competition[]> => {
    try {
      const response = await fetch(`${URL}/Competitions`);
      if (!response.ok) {
        throw new Error(`Network response was not ok: ${response.statusText}`);
      }
      const data: Competition[] = await response.json();
      return data;
    } catch (error) {
      console.error('Error fetching competitions:', error);
      throw error; 
    }
  };