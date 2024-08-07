import { useState, useEffect } from 'react';
import { fetchClubs } from '../../../features/footballData-feature/api/clubApi';
import { Club } from '../../../features/footballData-feature/types';

export const useClubs = (competitionId: string | null) => {
    const [clubs, setClubs] = useState<Club[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const loadClubs = async () => {
            if (competitionId) {
                setLoading(true);
                try {
                    const data = await fetchClubs(competitionId);
                    setClubs(data);
                    setLoading(false);
                } catch (err) {
                    if (err instanceof Error) {
                        setError(err.message);
                    } else {
                        setError('An unknown error occurred');
                    }
                    setLoading(false);
                }
            }
        };

        loadClubs();
    }, [competitionId]);

    return { clubs, loading, error };
};
