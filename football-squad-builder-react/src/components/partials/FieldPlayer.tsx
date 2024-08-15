import { Player } from '../../features/footballData-feature/types';



function FieldPlayer({ player }: { player: Player }) {
 return (
   <>
   <article className='field-player'>
       <div className='field-player-img-container'>
           <img className='field-player-img' src={player.imageURL} alt={`${player.name}'s image`} />
       </div>

       <div className='field-player-profile'>
               <p>{player.jerseyNumber} {player.name}</p>
       </div>
   </article>
   </>
 )
}

export default FieldPlayer
