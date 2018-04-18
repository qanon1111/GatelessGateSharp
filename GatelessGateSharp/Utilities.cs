﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace GatelessGateSharp
{
    static class Utilities
    {
        static long[] sDAGSizes = {
            1073739904, 1082130304, 1090514816, 1098906752, 1107293056, 
            1115684224, 1124070016, 1132461952, 1140849536, 1149232768, 
            1157627776, 1166013824, 1174404736, 1182786944, 1191180416, 
            1199568512, 1207958912, 1216345216, 1224732032, 1233124736, 
            1241513344, 1249902464, 1258290304, 1266673792, 1275067264, 
            1283453312, 1291844992, 1300234112, 1308619904, 1317010048, 
            1325397376, 1333787776, 1342176128, 1350561664, 1358954368, 
            1367339392, 1375731584, 1384118144, 1392507008, 1400897408, 
            1409284736, 1417673344, 1426062464, 1434451072, 1442839168, 
            1451229056, 1459615616, 1468006016, 1476394112, 1484782976, 
            1493171584, 1501559168, 1509948032, 1518337664, 1526726528, 
            1535114624, 1543503488, 1551892096, 1560278656, 1568669056, 
            1577056384, 1585446272, 1593831296, 1602219392, 1610610304, 
            1619000192, 1627386752, 1635773824, 1644164224, 1652555648, 
            1660943488, 1669332608, 1677721216, 1686109312, 1694497664, 
            1702886272, 1711274624, 1719661184, 1728047744, 1736434816, 
            1744829056, 1753218944, 1761606272, 1769995904, 1778382464, 
            1786772864, 1795157888, 1803550592, 1811937664, 1820327552, 
            1828711552, 1837102976, 1845488768, 1853879936, 1862269312, 
            1870656896, 1879048064, 1887431552, 1895825024, 1904212096, 
            1912601216, 1920988544, 1929379456, 1937765504, 1946156672, 
            1954543232, 1962932096, 1971321728, 1979707264, 1988093056, 
            1996487552, 2004874624, 2013262208, 2021653888, 2030039936, 
            2038430848, 2046819968, 2055208576, 2063596672, 2071981952, 
            2080373632, 2088762752, 2097149056, 2105539712, 2113928576, 
            2122315136, 2130700672, 2139092608, 2147483264, 2155872128, 
            2164257664, 2172642176, 2181035392, 2189426048, 2197814912, 
            2206203008, 2214587264, 2222979712, 2231367808, 2239758208, 
            2248145024, 2256527744, 2264922752, 2273312128, 2281701248, 
            2290086272, 2298476672, 2306867072, 2315251072, 2323639168, 
            2332032128, 2340420224, 2348808064, 2357196416, 2365580416, 
            2373966976, 2382363008, 2390748544, 2399139968, 2407530368, 
            2415918976, 2424307328, 2432695424, 2441084288, 2449472384, 
            2457861248, 2466247808, 2474637184, 2483026816, 2491414144, 
            2499803776, 2508191872, 2516582272, 2524970368, 2533359232, 
            2541743488, 2550134144, 2558525056, 2566913408, 2575301504, 
            2583686528, 2592073856, 2600467328, 2608856192, 2617240448, 
            2625631616, 2634022016, 2642407552, 2650796416, 2659188352, 
            2667574912, 2675965312, 2684352896, 2692738688, 2701130624, 
            2709518464, 2717907328, 2726293376, 2734685056, 2743073152, 
            2751462016, 2759851648, 2768232832, 2776625536, 2785017728, 
            2793401984, 2801794432, 2810182016, 2818571648, 2826959488, 
            2835349376, 2843734144, 2852121472, 2860514432, 2868900992, 
            2877286784, 2885676928, 2894069632, 2902451584, 2910843008, 
            2919234688, 2927622784, 2936011648, 2944400768, 2952789376, 
            2961177728, 2969565568, 2977951616, 2986338944, 2994731392, 
            3003120256, 3011508352, 3019895936, 3028287104, 3036675968, 
            3045063808, 3053452928, 3061837696, 3070228352, 3078615424, 
            3087003776, 3095394944, 3103782272, 3112173184, 3120562048, 
            3128944768, 3137339264, 3145725056, 3154109312, 3162505088, 
            3170893184, 3179280256, 3187669376, 3196056704, 3204445568, 
            3212836736, 3221224064, 3229612928, 3238002304, 3246391168, 
            3254778496, 3263165824, 3271556224, 3279944576, 3288332416, 
            3296719232, 3305110912, 3313500032, 3321887104, 3330273152, 
            3338658944, 3347053184, 3355440512, 3363827072, 3372220288, 
            3380608384, 3388997504, 3397384576, 3405774208, 3414163072, 
            3422551936, 3430937984, 3439328384, 3447714176, 3456104576, 
            3464493952, 3472883584, 3481268864, 3489655168, 3498048896, 
            3506434432, 3514826368, 3523213952, 3531603584, 3539987072, 
            3548380288, 3556763264, 3565157248, 3573545344, 3581934464, 
            3590324096, 3598712704, 3607098752, 3615488384, 3623877248, 
            3632265856, 3640646528, 3649043584, 3657430144, 3665821568, 
            3674207872, 3682597504, 3690984832, 3699367808, 3707764352, 
            3716152448, 3724541056, 3732925568, 3741318016, 3749706368, 
            3758091136, 3766481536, 3774872704, 3783260032, 3791650432, 
            3800036224, 3808427648, 3816815488, 3825204608, 3833592704, 
            3841981568, 3850370432, 3858755968, 3867147904, 3875536256, 
            3883920512, 3892313728, 3900702592, 3909087872, 3917478784, 
            3925868416, 3934256512, 3942645376, 3951032192, 3959422336, 
            3967809152, 3976200064, 3984588416, 3992974976, 4001363584, 
            4009751168, 4018141312, 4026530432, 4034911616, 4043308928, 
            4051695488, 4060084352, 4068472448, 4076862848, 4085249408, 
            4093640576, 4102028416, 4110413696, 4118805632, 4127194496, 
            4135583104, 4143971968, 4152360832, 4160746112, 4169135744, 
            4177525888, 4185912704, 4194303616, 4202691968, 4211076736, 
            4219463552, 4227855488, 4236246656, 4244633728, 4253022848, 
            4261412224, 4269799808, 4278184832, 4286578048, 4294962304, 
            4303349632, 4311743104, 4320130432, 4328521088, 4336909184, 
            4345295488, 4353687424, 4362073472, 4370458496, 4378852736, 
            4387238528, 4395630208, 4404019072, 4412407424, 4420790656, 
            4429182848, 4437571456, 4445962112, 4454344064, 4462738048, 
            4471119232, 4479516544, 4487904128, 4496289664, 4504682368, 
            4513068416, 4521459584, 4529846144, 4538232704, 4546619776, 
            4555010176, 4563402112, 4571790208, 4580174464, 4588567936, 
            4596957056, 4605344896, 4613734016, 4622119808, 4630511488, 
            4638898816, 4647287936, 4655675264, 4664065664, 4672451968, 
            4680842624, 4689231488, 4697620352, 4706007424, 4714397056, 
            4722786176, 4731173248, 4739562368, 4747951744, 4756340608, 
            4764727936, 4773114496, 4781504384, 4789894784, 4798283648, 
            4806667648, 4815059584, 4823449472, 4831835776, 4840226176, 
            4848612224, 4857003392, 4865391488, 4873780096, 4882169728, 
            4890557312, 4898946944, 4907333248, 4915722368, 4924110976, 
            4932499328, 4940889728, 4949276032, 4957666432, 4966054784, 
            4974438016, 4982831488, 4991221376, 4999607168, 5007998848, 
            5016386432, 5024763776, 5033164672, 5041544576, 5049941888, 
            5058329728, 5066717056, 5075107456, 5083494272, 5091883904, 
            5100273536, 5108662144, 5117048192, 5125436032, 5133827456, 
            5142215296, 5150605184, 5158993024, 5167382144, 5175769472, 
            5184157568, 5192543872, 5200936064, 5209324928, 5217711232, 
            5226102656, 5234490496, 5242877312, 5251263872, 5259654016, 
            5268040832, 5276434304, 5284819328, 5293209728, 5301598592, 
            5309986688, 5318374784, 5326764416, 5335151488, 5343542144, 
            5351929472, 5360319872, 5368706944, 5377096576, 5385484928, 
            5393871232, 5402263424, 5410650496, 5419040384, 5427426944, 
            5435816576, 5444205952, 5452594816, 5460981376, 5469367936, 
            5477760896, 5486148736, 5494536832, 5502925952, 5511315328, 
            5519703424, 5528089984, 5536481152, 5544869504, 5553256064, 
            5561645696, 5570032768, 5578423936, 5586811264, 5595193216, 
            5603585408, 5611972736, 5620366208, 5628750464, 5637143936, 
            5645528192, 5653921408, 5662310272, 5670694784, 5679082624, 
            5687474048, 5695864448, 5704251008, 5712641408, 5721030272, 
            5729416832, 5737806208, 5746194304, 5754583936, 5762969984, 
            5771358592, 5779748224, 5788137856, 5796527488, 5804911232, 
            5813300608, 5821692544, 5830082176, 5838468992, 5846855552, 
            5855247488, 5863636096, 5872024448, 5880411008, 5888799872, 
            5897186432, 5905576832, 5913966976, 5922352768, 5930744704, 
            5939132288, 5947522432, 5955911296, 5964299392, 5972688256, 
            5981074304, 5989465472, 5997851008, 6006241408, 6014627968, 
            6023015552, 6031408256, 6039796096, 6048185216, 6056574848, 
            6064963456, 6073351808, 6081736064, 6090128768, 6098517632, 
            6106906496, 6115289216, 6123680896, 6132070016, 6140459648, 
            6148849024, 6157237376, 6165624704, 6174009728, 6182403712, 
            6190792064, 6199176064, 6207569792, 6215952256, 6224345216, 
            6232732544, 6241124224, 6249510272, 6257899136, 6266287744, 
            6274676864, 6283065728, 6291454336, 6299843456, 6308232064, 
            6316620928, 6325006208, 6333395584, 6341784704, 6350174848, 
            6358562176, 6366951296, 6375337856, 6383729536, 6392119168, 
            6400504192, 6408895616, 6417283456, 6425673344, 6434059136, 
            6442444672, 6450837376, 6459223424, 6467613056, 6476004224, 
            6484393088, 6492781952, 6501170048, 6509555072, 6517947008, 
            6526336384, 6534725504, 6543112832, 6551500672, 6559888768, 
            6568278656, 6576662912, 6585055616, 6593443456, 6601834112, 
            6610219648, 6618610304, 6626999168, 6635385472, 6643777408, 
            6652164224, 6660552832, 6668941952, 6677330048, 6685719424, 
            6694107776, 6702493568, 6710882176, 6719274112, 6727662976, 
            6736052096, 6744437632, 6752825984, 6761213824, 6769604224, 
            6777993856, 6786383488, 6794770816, 6803158144, 6811549312, 
            6819937664, 6828326528, 6836706176, 6845101696, 6853491328, 
            6861880448, 6870269312, 6878655104, 6887046272, 6895433344, 
            6903822208, 6912212864, 6920596864, 6928988288, 6937377152, 
            6945764992, 6954149248, 6962544256, 6970928768, 6979317376, 
            6987709312, 6996093824, 7004487296, 7012875392, 7021258624, 
            7029652352, 7038038912, 7046427776, 7054818944, 7063207808, 
            7071595136, 7079980928, 7088372608, 7096759424, 7105149824, 
            7113536896, 7121928064, 7130315392, 7138699648, 7147092352, 
            7155479168, 7163865728, 7172249984, 7180648064, 7189036672, 
            7197424768, 7205810816, 7214196608, 7222589824, 7230975104, 
            7239367552, 7247755904, 7256145536, 7264533376, 7272921472, 
            7281308032, 7289694848, 7298088832, 7306471808, 7314864512, 
            7323253888, 7331643008, 7340029568, 7348419712, 7356808832, 
            7365196672, 7373585792, 7381973888, 7390362752, 7398750592, 
            7407138944, 7415528576, 7423915648, 7432302208, 7440690304, 
            7449080192, 7457472128, 7465860992, 7474249088, 7482635648, 
            7491023744, 7499412608, 7507803008, 7516192384, 7524579968, 
            7532967296, 7541358464, 7549745792, 7558134656, 7566524032, 
            7574912896, 7583300992, 7591690112, 7600075136, 7608466816, 
            7616854912, 7625244544, 7633629824, 7642020992, 7650410368, 
            7658794112, 7667187328, 7675574912, 7683961984, 7692349568, 
            7700739712, 7709130368, 7717519232, 7725905536, 7734295424, 
            7742683264, 7751069056, 7759457408, 7767849088, 7776238208, 
            7784626816, 7793014912, 7801405312, 7809792128, 7818179968, 
            7826571136, 7834957184, 7843347328, 7851732352, 7860124544, 
            7868512384, 7876902016, 7885287808, 7893679744, 7902067072, 
            7910455936, 7918844288, 7927230848, 7935622784, 7944009344, 
            7952400256, 7960786048, 7969176704, 7977565312, 7985953408, 
            7994339968, 8002730368, 8011119488, 8019508096, 8027896192, 
            8036285056, 8044674688, 8053062272, 8061448832, 8069838464, 
            8078227328, 8086616704, 8095006592, 8103393664, 8111783552, 
            8120171392, 8128560256, 8136949376, 8145336704, 8153726848, 
            8162114944, 8170503296, 8178891904, 8187280768, 8195669632, 
            8204058496, 8212444544, 8220834176, 8229222272, 8237612672, 
            8246000768, 8254389376, 8262775168, 8271167104, 8279553664, 
            8287944064, 8296333184, 8304715136, 8313108352, 8321497984, 
            8329885568, 8338274432, 8346663296, 8355052928, 8363441536, 
            8371828352, 8380217984, 8388606592, 8396996224, 8405384576, 
            8413772672, 8422161536, 8430549376, 8438939008, 8447326592, 
            8455715456, 8464104832, 8472492928, 8480882048, 8489270656, 
            8497659776, 8506045312, 8514434944, 8522823808, 8531208832, 
            8539602304, 8547990656, 8556378752, 8564768384, 8573154176, 
            8581542784, 8589933952, 8598322816, 8606705024, 8615099264, 
            8623487872, 8631876992, 8640264064, 8648653952, 8657040256, 
            8665430656, 8673820544, 8682209152, 8690592128, 8698977152, 
            8707374464, 8715763328, 8724151424, 8732540032, 8740928384, 
            8749315712, 8757704576, 8766089344, 8774480768, 8782871936, 
            8791260032, 8799645824, 8808034432, 8816426368, 8824812928, 
            8833199488, 8841591424, 8849976448, 8858366336, 8866757248, 
            8875147136, 8883532928, 8891923328, 8900306816, 8908700288, 
            8917088384, 8925478784, 8933867392, 8942250368, 8950644608, 
            8959032704, 8967420544, 8975809664, 8984197504, 8992584064, 
            9000976256, 9009362048, 9017752448, 9026141312, 9034530688, 
            9042917504, 9051307904, 9059694208, 9068084864, 9076471424, 
            9084861824, 9093250688, 9101638528, 9110027648, 9118416512, 
            9126803584, 9135188096, 9143581312, 9151969664, 9160356224, 
            9168747136, 9177134464, 9185525632, 9193910144, 9202302848, 
            9210690688, 9219079552, 9227465344, 9235854464, 9244244864, 
            9252633472, 9261021824, 9269411456, 9277799296, 9286188928, 
            9294574208, 9302965888, 9311351936, 9319740032, 9328131968, 
            9336516736, 9344907392, 9353296768, 9361685888, 9370074752, 
            9378463616, 9386849408, 9395239808, 9403629184, 9412016512, 
            9420405376, 9428795008, 9437181568, 9445570688, 9453960832, 
            9462346624, 9470738048, 9479121536, 9487515008, 9495903616, 
            9504289664, 9512678528, 9521067904, 9529456256, 9537843584, 
            9546233728, 9554621312, 9563011456, 9571398784, 9579788672, 
            9588178304, 9596567168, 9604954496, 9613343104, 9621732992, 
            9630121856, 9638508416, 9646898816, 9655283584, 9663675776, 
            9672061312, 9680449664, 9688840064, 9697230464, 9705617536, 
            9714003584, 9722393984, 9730772608, 9739172224, 9747561088, 
            9755945344, 9764338816, 9772726144, 9781116544, 9789503872, 
            9797892992, 9806282624, 9814670464, 9823056512, 9831439232, 
            9839833984, 9848224384, 9856613504, 9865000576, 9873391232, 
            9881772416, 9890162816, 9898556288, 9906940544, 9915333248, 
            9923721088, 9932108672, 9940496512, 9948888448, 9957276544, 
            9965666176, 9974048384, 9982441088, 9990830464, 9999219584, 
            10007602816, 10015996544, 10024385152, 10032774016, 10041163648, 
            10049548928, 10057940096, 10066329472, 10074717824, 10083105152, 
            10091495296, 10099878784, 10108272256, 10116660608, 10125049216, 
            10133437312, 10141825664, 10150213504, 10158601088, 10166991232, 
            10175378816, 10183766144, 10192157312, 10200545408, 10208935552, 
            10217322112, 10225712768, 10234099328, 10242489472, 10250876032, 
            10259264896, 10267656064, 10276042624, 10284429184, 10292820352, 
            10301209472, 10309598848, 10317987712, 10326375296, 10334763392, 
            10343153536, 10351541632, 10359930752, 10368318592, 10376707456, 
            10385096576, 10393484672, 10401867136, 10410262144, 10418647424, 
            10427039104, 10435425664, 10443810176, 10452203648, 10460589952, 
            10468982144, 10477369472, 10485759104, 10494147712, 10502533504, 
            10510923392, 10519313536, 10527702656, 10536091264, 10544478592, 
            10552867712, 10561255808, 10569642368, 10578032768, 10586423168, 
            10594805632, 10603200128, 10611588992, 10619976064, 10628361344, 
            10636754048, 10645143424, 10653531776, 10661920384, 10670307968, 
            10678696832, 10687086464, 10695475072, 10703863168, 10712246144, 
            10720639616, 10729026688, 10737414784, 10745806208, 10754190976, 
            10762581376, 10770971264, 10779356288, 10787747456, 10796135552, 
            10804525184, 10812915584, 10821301888, 10829692288, 10838078336, 
            10846469248, 10854858368, 10863247232, 10871631488, 10880023424, 
            10888412032, 10896799616, 10905188992, 10913574016, 10921964672, 
            10930352768, 10938742912, 10947132544, 10955518592, 10963909504, 
            10972298368, 10980687488, 10989074816, 10997462912, 11005851776, 
            11014241152, 11022627712, 11031017344, 11039403904, 11047793024, 
            11056184704, 11064570752, 11072960896, 11081343872, 11089737856, 
            11098128256, 11106514816, 11114904448, 11123293568, 11131680128, 
            11140065152, 11148458368, 11156845696, 11165236864, 11173624192, 
            11182013824, 11190402688, 11198790784, 11207179136, 11215568768, 
            11223957376, 11232345728, 11240734592, 11249122688, 11257511296, 
            11265899648, 11274285952, 11282675584, 11291065472, 11299452544, 
            11307842432, 11316231296, 11324616832, 11333009024, 11341395584, 
            11349782656, 11358172288, 11366560384, 11374950016, 11383339648, 
            11391721856, 11400117376, 11408504192, 11416893568, 11425283456, 
            11433671552, 11442061184, 11450444672, 11458837888, 11467226752, 
            11475611776, 11484003968, 11492392064, 11500780672, 11509169024, 
            11517550976, 11525944448, 11534335616, 11542724224, 11551111808, 
            11559500672, 11567890304, 11576277376, 11584667008, 11593056128, 
            11601443456, 11609830016, 11618221952, 11626607488, 11634995072, 
            11643387776, 11651775104, 11660161664, 11668552576, 11676940928, 
            11685330304, 11693718656, 11702106496, 11710496128, 11718882688, 
            11727273088, 11735660416, 11744050048, 11752437376, 11760824704, 
            11769216128, 11777604736, 11785991296, 11794381952, 11802770048, 
            11811157888, 11819548544, 11827932544, 11836324736, 11844713344, 
            11853100928, 11861486464, 11869879936, 11878268032, 11886656896, 
            11895044992, 11903433088, 11911822976, 11920210816, 11928600448, 
            11936987264, 11945375872, 11953761152, 11962151296, 11970543488, 
            11978928512, 11987320448, 11995708288, 12004095104, 12012486272, 
            12020875136, 12029255552, 12037652096, 12046039168, 12054429568, 
            12062813824, 12071206528, 12079594624, 12087983744, 12096371072, 
            12104759936, 12113147264, 12121534592, 12129924992, 12138314624, 
            12146703232, 12155091584, 12163481216, 12171864704, 12180255872, 
            12188643968, 12197034112, 12205424512, 12213811328, 12222199424, 
            12230590336, 12238977664, 12247365248, 12255755392, 12264143488, 
            12272531584, 12280920448, 12289309568, 12297694592, 12306086528, 
            12314475392, 12322865024, 12331253632, 12339640448, 12348029312, 
            12356418944, 12364805248, 12373196672, 12381580928, 12389969024, 
            12398357632, 12406750592, 12415138432, 12423527552, 12431916416, 
            12440304512, 12448692352, 12457081216, 12465467776, 12473859968, 
            12482245504, 12490636672, 12499025536, 12507411584, 12515801728, 
            12524190592, 12532577152, 12540966272, 12549354368, 12557743232, 
            12566129536, 12574523264, 12582911872, 12591299456, 12599688064, 
            12608074624, 12616463488, 12624845696, 12633239936, 12641631616, 
            12650019968, 12658407296, 12666795136, 12675183232, 12683574656, 
            12691960192, 12700350592, 12708740224, 12717128576, 12725515904, 
            12733906816, 12742295168, 12750680192, 12759071872, 12767460736, 
            12775848832, 12784236928, 12792626816, 12801014656, 12809404288, 
            12817789312, 12826181504, 12834568832, 12842954624, 12851345792, 
            12859732352, 12868122496, 12876512128, 12884901248, 12893289088, 
            12901672832, 12910067584, 12918455168, 12926842496, 12935232896, 
            12943620736, 12952009856, 12960396928, 12968786816, 12977176192, 
            12985563776, 12993951104, 13002341504, 13010730368, 13019115392, 
            13027506304, 13035895168, 13044272512, 13052673152, 13061062528, 
            13069446272, 13077838976, 13086227072, 13094613632, 13103000192, 
            13111393664, 13119782528, 13128157568, 13136559232, 13144945024, 
            13153329536, 13161724288, 13170111872, 13178502784, 13186884736, 
            13195279744, 13203667072, 13212057472, 13220445824, 13228832128, 
            13237221248, 13245610624, 13254000512, 13262388352, 13270777472, 
            13279166336, 13287553408, 13295943296, 13304331904, 13312719488, 
            13321108096, 13329494656, 13337885824, 13346274944, 13354663808, 
            13363051136, 13371439232, 13379825024, 13388210816, 13396605056, 
            13404995456, 13413380224, 13421771392, 13430159744, 13438546048, 
            13446937216, 13455326848, 13463708288, 13472103808, 13480492672, 
            13488875648, 13497269888, 13505657728, 13514045312, 13522435712, 
            13530824576, 13539210112, 13547599232, 13555989376, 13564379008, 
            13572766336, 13581154432, 13589544832, 13597932928, 13606320512, 
            13614710656, 13623097472, 13631477632, 13639874944, 13648264064, 
            13656652928, 13665041792, 13673430656, 13681818496, 13690207616, 
            13698595712, 13706982272, 13715373184, 13723762048, 13732150144, 
            13740536704, 13748926592, 13757316224, 13765700992, 13774090112, 
            13782477952, 13790869376, 13799259008, 13807647872, 13816036736, 
            13824425344, 13832814208, 13841202304, 13849591424, 13857978752, 
            13866368896, 13874754688, 13883145344, 13891533184, 13899919232, 
            13908311168, 13916692096, 13925085056, 13933473152, 13941866368, 
            13950253696, 13958643584, 13967032192, 13975417216, 13983807616, 
            13992197504, 14000582272, 14008973696, 14017363072, 14025752192, 
            14034137984, 14042528384, 14050918016, 14059301504, 14067691648, 
            14076083584, 14084470144, 14092852352, 14101249664, 14109635968, 
            14118024832, 14126407552, 14134804352, 14143188608, 14151577984, 
            14159968384, 14168357248, 14176741504, 14185127296, 14193521024, 
            14201911424, 14210301824, 14218685056, 14227067264, 14235467392, 
            14243855488, 14252243072, 14260630144, 14269021568, 14277409408, 
            14285799296, 14294187904, 14302571392, 14310961792, 14319353728, 
            14327738752, 14336130944, 14344518784, 14352906368, 14361296512, 
            14369685376, 14378071424, 14386462592, 14394848128, 14403230848, 
            14411627392, 14420013952, 14428402304, 14436793472, 14445181568, 
            14453569664, 14461959808, 14470347904, 14478737024, 14487122816, 
            14495511424, 14503901824, 14512291712, 14520677504, 14529064832, 
            14537456768, 14545845632, 14554234496, 14562618496, 14571011456, 
            14579398784, 14587789184, 14596172672, 14604564608, 14612953984, 
            14621341312, 14629724288, 14638120832, 14646503296, 14654897536, 
            14663284864, 14671675264, 14680061056, 14688447616, 14696835968, 
            14705228416, 14713616768, 14722003328, 14730392192, 14738784128, 
            14747172736, 14755561088, 14763947648, 14772336512, 14780725376, 
            14789110144, 14797499776, 14805892736, 14814276992, 14822670208, 
            14831056256, 14839444352, 14847836032, 14856222848, 14864612992, 
            14872997504, 14881388672, 14889775744, 14898165376, 14906553472, 
            14914944896, 14923329664, 14931721856, 14940109696, 14948497024, 
            14956887424, 14965276544, 14973663616, 14982053248, 14990439808, 
            14998830976, 15007216768, 15015605888, 15023995264, 15032385152, 
            15040768384, 15049154944, 15057549184, 15065939072, 15074328448, 
            15082715008, 15091104128, 15099493504, 15107879296, 15116269184, 
            15124659584, 15133042304, 15141431936, 15149824384, 15158214272, 
            15166602368, 15174991232, 15183378304, 15191760512, 15200154496, 
            15208542592, 15216931712, 15225323392, 15233708416, 15242098048, 
            15250489216, 15258875264, 15267265408, 15275654528, 15284043136, 
            15292431488, 15300819584, 15309208192, 15317596544, 15325986176, 
            15334374784, 15342763648, 15351151744, 15359540608, 15367929728, 
            15376318336, 15384706432, 15393092992, 15401481856, 15409869952, 
            15418258816, 15426649984, 15435037568, 15443425664, 15451815296, 
            15460203392, 15468589184, 15476979328, 15485369216, 15493755776, 
            15502146944, 15510534272, 15518924416, 15527311232, 15535699072, 
            15544089472, 15552478336, 15560866688, 15569254528, 15577642624, 
            15586031488, 15594419072, 15602809472, 15611199104, 15619586432, 
            15627975296, 15636364928, 15644753792, 15653141888, 15661529216, 
            15669918848, 15678305152, 15686696576, 15695083136, 15703474048, 
            15711861632, 15720251264, 15728636288, 15737027456, 15745417088, 
            15753804928, 15762194048, 15770582656, 15778971008, 15787358336, 
            15795747712, 15804132224, 15812523392, 15820909696, 15829300096, 
            15837691264, 15846071936, 15854466944, 15862855808, 15871244672, 
            15879634816, 15888020608, 15896409728, 15904799104, 15913185152, 
            15921577088, 15929966464, 15938354816, 15946743424, 15955129472, 
            15963519872, 15971907968, 15980296064, 15988684928, 15997073024, 
            16005460864, 16013851264, 16022241152, 16030629248, 16039012736, 
            16047406976, 16055794816, 16064181376, 16072571264, 16080957824, 
            16089346688, 16097737856, 16106125184, 16114514816, 16122904192, 
            16131292544, 16139678848, 16148066944, 16156453504, 16164839552, 
            16173236096, 16181623424, 16190012032, 16198401152, 16206790528, 
            16215177344, 16223567744, 16231956352, 16240344704, 16248731008, 
            16257117824, 16265504384, 16273898624, 16282281856, 16290668672, 
            16299064192, 16307449216, 16315842176, 16324230016, 16332613504, 
            16341006464, 16349394304, 16357783168, 16366172288, 16374561664, 
            16382951296, 16391337856, 16399726208, 16408116352, 16416505472, 
            16424892032, 16433282176, 16441668224, 16450058624, 16458448768, 
            16466836864, 16475224448, 16483613056, 16492001408, 16500391808, 
            16508779648, 16517166976, 16525555328, 16533944192, 16542330752, 
            16550719616, 16559110528, 16567497088, 16575888512, 16584274816, 
            16592665472, 16601051008, 16609442944, 16617832064, 16626218624, 
            16634607488, 16642996096, 16651385728, 16659773824, 16668163712, 
            16676552576, 16684938112, 16693328768, 16701718144, 16710095488, 
            16718492288, 16726883968, 16735272832, 16743661184, 16752049792, 
            16760436608, 16768827008, 16777214336, 16785599104, 16793992832, 
            16802381696, 16810768768, 16819151744, 16827542656, 16835934848, 
            16844323712, 16852711552, 16861101952, 16869489536, 16877876864, 
            16886265728, 16894653056, 16903044736, 16911431296, 16919821696, 
            16928207488, 16936592768, 16944987776, 16953375616, 16961763968, 
            16970152832, 16978540928, 16986929536, 16995319168, 17003704448, 
            17012096896, 17020481152, 17028870784, 17037262208, 17045649536, 
            17054039936, 17062426496, 17070814336, 17079205504, 17087592064, 
            17095978112, 17104369024, 17112759424, 17121147776, 17129536384, 
            17137926016, 17146314368, 17154700928, 17163089792, 17171480192, 
            17179864192, 17188256896, 17196644992, 17205033856, 17213423488, 
            17221811072, 17230198912, 17238588032, 17246976896, 17255360384, 
            17263754624, 17272143232, 17280530048, 17288918912, 17297309312, 
            17305696384, 17314085504, 17322475136, 17330863744, 17339252096, 
            17347640192, 17356026496, 17364413824, 17372796544, 17381190016, 
            17389583488, 17397972608, 17406360704, 17414748544, 17423135872, 
            17431527296, 17439915904, 17448303232, 17456691584, 17465081728, 
            17473468288, 17481857408, 17490247552, 17498635904, 17507022464, 
            17515409024, 17523801728, 17532189824, 17540577664, 17548966016, 
            17557353344, 17565741184, 17574131584, 17582519168, 17590907008, 
            17599296128, 17607687808, 17616076672, 17624455808, 17632852352, 
            17641238656, 17649630848, 17658018944, 17666403968, 17674794112, 
            17683178368, 17691573376, 17699962496, 17708350592, 17716739968, 
            17725126528, 17733517184, 17741898112, 17750293888, 17758673024, 
            17767070336, 17775458432, 17783848832, 17792236928, 17800625536, 
            17809012352, 17817402752, 17825785984, 17834178944, 17842563968, 
            17850955648, 17859344512, 17867732864, 17876119424, 17884511872, 
            17892900224, 17901287296, 17909677696, 17918058112, 17926451072, 
            17934843776, 17943230848, 17951609216, 17960008576, 17968397696, 
            17976784256, 17985175424, 17993564032, 18001952128, 18010339712, 
            18018728576, 18027116672, 18035503232, 18043894144, 18052283264, 
            18060672128, 18069056384, 18077449856, 18085837184, 18094225792, 
            18102613376, 18111004544, 18119388544, 18127781248, 18136170368, 
            18144558976, 18152947328, 18161336192, 18169724288, 18178108544, 
            18186498944, 18194886784, 18203275648, 18211666048, 18220048768, 
            18228444544, 18236833408, 18245220736
        };

        public static long GetDAGSize(int epoch)
        {
            return sDAGSizes[epoch];
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static byte[] FlipByteArrayUInt32(byte[] ba)
        {
            byte[] result = new byte[ba.Length];
            for (int i = 0; i + 3 < ba.Length; i += 4)
            {
                result[i + 0] = ba[i + 3];
                result[i + 1] = ba[i + 2];
                result[i + 2] = ba[i + 1];
                result[i + 3] = ba[i + 0];
            }
            return result;
        }

        public static byte[] StringToByteArray(String hex)
        {
            int numChars = hex.Length;
            byte[] bytes = new byte[numChars / 2];
            for (int i = 0; i < numChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static byte[] StringToByteArrayReverse(String hex)
        {
            int numChars = hex.Length;
            byte[] bytes = new byte[numChars / 2];
            for (int i = 0; i < numChars; i += 2)
                bytes[(numChars / 2) - (i / 2) - 1] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static long MeasurePingRoundtripTime(string host)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            options.DontFragment = true;
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 3;
            PingReply reply = pingSender.Send(host, timeout, buffer, options);
            return (reply.Status == IPStatus.Success) ? reply.RoundtripTime : -1;
        }

        [System.Runtime.InteropServices.DllImport("msvcrt.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        extern static uint _controlfp(uint newcw,uint mask);

        const uint _MCW_EM=0x0008001f;
        const uint _EM_INVALID=0x00000010;

        public static void FixFPU()
        {
            _controlfp(_MCW_EM, _EM_INVALID);
        }

        public static Form GetAutoClosingForm(int wait = 10)
        {
            var w = new Form() { Size = new System.Drawing.Size(0, 0), TopMost = true };
            Task.Delay(TimeSpan.FromSeconds(wait)).ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());
            w.BringToFront();
            return w;
        }

        public static IEnumerable<T> FindAllChildrenByType<T>(this Control control) {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            return controls
                .OfType<T>()
                .Concat<T>(controls.SelectMany<Control, T>(ctrl => FindAllChildrenByType<T>(ctrl)));
        }

        public static bool IsDevFeeAddress(string s) {
            return (new List<string> {
                Parameters.DevFeeBitcoinAddress,
                Parameters.DevFeeEthereumAddress,
                Parameters.DevFeeMoneroAddress,
                Parameters.DevFeePascalAddress,
                Parameters.DevFeeLbryAddress,
                Parameters.DevFeeZcashAddress,
                Parameters.DevFeeFeathercoinAddress,
                Parameters.DevFeeBitcoinAddress + Parameters.DevFeeUsernamePostfix,
                Parameters.DevFeeEthereumAddress + Parameters.DevFeeUsernamePostfix,
                Parameters.DevFeeMoneroAddress + Parameters.DevFeeUsernamePostfix,
                Parameters.DevFeePascalAddress + Parameters.DevFeeUsernamePostfix,
                Parameters.DevFeeLbryAddress + Parameters.DevFeeUsernamePostfix,
                Parameters.DevFeeZcashAddress + Parameters.DevFeeUsernamePostfix,
                Parameters.DevFeeFeathercoinAddress + Parameters.DevFeeUsernamePostfix,
            }).Contains(s);
        }

        public static void SleepWithDoEvents(int timeout) {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < timeout) {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
            }
        }

        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
