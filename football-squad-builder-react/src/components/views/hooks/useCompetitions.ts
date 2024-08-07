import { useState, useEffect } from 'react';
import { fetchCompetitions } from '../../../features/footballData-feature/api/competitionApi';
import { Competition } from '../../../features/footballData-feature/types';


export const useCompetitions = () => {
    const [competitions, setCompetitions] = useState<Competition[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const loadCompetitions = async () => {
            try {
                const data = await fetchCompetitions();
                setCompetitions(data);
                setLoading(false);
            } catch (err) {
                if (err instanceof Error) {
                    setError(err.message);
                } else {
                    setError('An unknown error occurred');
                }
                setLoading(false);
            }
        };

        loadCompetitions();
    }, []);

    return { competitions, loading, error };
};