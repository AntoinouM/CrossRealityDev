/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_AMBIENCE = 278617630U;
        static const AkUniqueID PLAY_AMBIENCE_OUTSIDE = 26975710U;
        static const AkUniqueID PLAY_COMPUTER = 1984956505U;
        static const AkUniqueID PLAY_DAMAGE = 784302017U;
        static const AkUniqueID PLAY_DOOR = 2547633870U;
        static const AkUniqueID PLAY_FOOTSTEPS_INSIDE = 451415118U;
        static const AkUniqueID PLAY_FOOTSTEPS_OUTSIDE = 587954731U;
        static const AkUniqueID PLAY_GAMEOVER = 3174629258U;
        static const AkUniqueID PLAY_HEARTBEAT = 3765695918U;
        static const AkUniqueID PLAY_LANDING = 2323405115U;
        static const AkUniqueID PLAY_MAIN_MENU = 3306210749U;
        static const AkUniqueID PLAY_PARTICLES = 3967491579U;
        static const AkUniqueID PLAY_PICK_UP = 964566375U;
        static const AkUniqueID PLAY_REPAIR = 3218577785U;
        static const AkUniqueID PLAY_SIGH = 3892669207U;
        static const AkUniqueID PLAY_SLEEP = 3734418179U;
        static const AkUniqueID PLAY_SQUARED_DEATH = 4101564066U;
        static const AkUniqueID PLAY_SQUARED_ENEMY = 3099317768U;
        static const AkUniqueID PLAY_SQUID = 3382913736U;
        static const AkUniqueID PLAY_SQUID_DEATH = 2851848159U;
        static const AkUniqueID PLAY_VOLCANOS = 1073726411U;
        static const AkUniqueID PLAY_WINNING = 1958657586U;
        static const AkUniqueID STOP_SQUARED_ENEMY = 876808746U;
        static const AkUniqueID STOP_SQUID = 2270141638U;
        static const AkUniqueID STOP_VOLCANOS = 1029362689U;
    } // namespace EVENTS

    namespace SWITCHES
    {
        namespace COMPUTER
        {
            static const AkUniqueID GROUP = 2376682602U;

            namespace SWITCH
            {
                static const AkUniqueID BOOT = 1761500993U;
                static const AkUniqueID CANCEL = 2760337059U;
                static const AkUniqueID CLICK = 1584507803U;
                static const AkUniqueID TURN_OFF = 188147178U;
            } // namespace SWITCH
        } // namespace COMPUTER

        namespace GAMEOVER
        {
            static const AkUniqueID GROUP = 4158285989U;

            namespace SWITCH
            {
                static const AkUniqueID BREATH = 1326786195U;
                static const AkUniqueID HIT = 1116398592U;
            } // namespace SWITCH
        } // namespace GAMEOVER

        namespace PICKUP
        {
            static const AkUniqueID GROUP = 3978245845U;

            namespace SWITCH
            {
                static const AkUniqueID CRYSTAL = 3444057113U;
                static const AkUniqueID ORB = 595159780U;
            } // namespace SWITCH
        } // namespace PICKUP

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID MASTERVOLUME = 2918011349U;
        static const AkUniqueID OXYGEN = 3660512661U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID COMPUTER = 2376682602U;
        static const AkUniqueID ENEMIES = 2242381963U;
        static const AkUniqueID HEARTBEAT = 2179486487U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MOVEMENT = 2129636626U;
        static const AkUniqueID PLAYER = 1069431850U;
        static const AkUniqueID WORLD = 2609808943U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
