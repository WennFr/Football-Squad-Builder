import { useState, useEffect } from 'react';
import { fetchPlayers } from '../../../features/footballData-feature/api/playerApi';
import { Player } from '../../../features/footballData-feature/types';

export const usePlayers = (clubId: string | null) => {
    const [players, setPlayers] = useState<Player[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const loadPlayers = async () => {
            if (clubId) {
                setLoading(true);
                try {
                    const data = await fetchPlayers(clubId);
                    setPlayers(data);
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

        loadPlayers();
    }, [clubId]);

    return { players, loading, error };
};
