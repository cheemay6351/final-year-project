var MongoClient = require("mongodb").MongoClient;
var connect = require("./connect"); //url from connect module
var client = new MongoClient(connect.database.url, {
    useUnifiedTopology: true,
});

var dbName = "Beers_Criteria"; //Database name

//2023 American Geriatrics Society Beers Criteria® for medications that should be avoided or have their dosage reduced with varying levels of kidney function in older adults.
async function insertMed(db) {
    var collection = db.collection('Table6');
    var userObjects1 = [
        {
            ID: 1,
            Drug_Category: 'Anti-infective',
            Drug_Name: 'Ciprofloxacin',
            CrCl: '<30',
            Rationale: 'Increased risk of CNS effects (e.g., seizures, confusion) and tendon rupture.',
            Recommendation: 'Dosages used to treat common infections typically require reduction when CrCl <30 mL/min.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 2,
            Drug_Category: 'Anti-infective',
            Drug_Name: 'Nitrofurantoin',
            CrCl: '<30',
            Rationale: 'Potential for pulmonary toxicity, hepatoxicity, and peripheral neuropathy, especially with long-term use. (See also Table 2).',
            Recommendation: 'Avoid if CrCl <30 mL/min',
            Quality_of_Evidence: 'Low',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 3,
            Drug_Category: 'Anti-infective',
            Drug_Name: 'Trimethoprim-sulfamethoxazole',
            CrCl: '<30',
            Rationale: 'Increased risk of worsening of kidney function and hyperkalemia; risk of hyperkalemia especially prominent with concurrent use of an ACE, ARB, or ARNI.',
            Recommendation: 'Reduce dosage if CrCl is 15-29 mL/min.\nAvoid if CrCl <15 mL/min.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 4,
            Drug_Category: 'Cardiovascular and antithrombotics',
            Drug_Name: 'Amiloride',
            CrCl: '<30',
            Rationale: 'Hyperkalemia and hyponatremia',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 5,
            Drug_Category: 'Cardiovascular and antithrombotics',
            Drug_Name: 'Dabigatran',
            CrCl: '<30',
            Rationale: 'Lack of evidence for efficacy and safety in individuals with a CrCl <30 mL/min. Label dose for patients with CrCl 15–30 mL/min based on pharmacokinetic data.',
            Recommendation: 'Avoid when CrCl <30 mL/min; dose adjustment is advised when CrCl >30 mL/min in the presence of drug-drug interactions.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 6,
            Drug_Category: 'Cardiovascular and antithrombotics',
            Drug_Name: 'Dofetilide',
            CrCl: '<60',
            Rationale: 'QTc prolongation and torsades de pointes.',
            Recommendation: 'Reduce dose if CrCl is 20-59 mL/min.\nAvoid if CrCl <20 mL/min.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 7,
            Drug_Category: 'Cardiovascular and antithrombotics',
            Drug_Name: 'Edoxaban',
            CrCl: '15-50\n<15 or > 95',
            Rationale: 'Lack of evidence of efficacy or safety in patients with CrCl <30 mL/min.',
            Recommendation: 'Reduce dose if CrCl is 15-50 mL/min.\nAvoid if CrCl <15 or > 95 mL/min.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 8,
            Drug_Category: 'Cardiovascular and antithrombotics',
            Drug_Name: 'Enoxaparin',
            CrCl: '<30',
            Rationale: 'Increased risk of bleeding',
            Recommendation: 'Reduce dose',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 9,
            Drug_Category: 'Cardiovascular and antithrombotics',
            Drug_Name: 'Fondaparinux',
            CrCl: '<30',
            Rationale: 'Increased risk of bleeding',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 10,
            Drug_Category: 'Cardiovascular and antithrombotics',
            Drug_Name: 'Rivaroxaban',
            CrCl: '<50',
            Rationale: 'Lack of efficacy or safety evidence in people with CrCl <15 mL/min; limited evidence for CrCl 15-30 mL/min.',
            Recommendation: 'Avoid if CrCl <15 mL/min.\nReduce the dose if CrCl is 15-50 mL/min following manufacturer dosing recommendations based on indication-specific dosing.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 11,
            Drug_Category: 'Cardiovascular and antithrombotics',
            Drug_Name: 'Spironolactone',
            CrCl: '<30',
            Rationale: 'Hyperkalemia',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 12,
            Drug_Category: 'Cardiovascular and antithrombotics',
            Drug_Name: 'Triamterene',
            CrCl: '<30',
            Rationale: 'Hyperkalemia and hyponatremia',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 13,
            Drug_Category: 'Central nervous system and analgesics',
            Drug_Name: 'Baclofen',
            CrCl: 'eGFR <60',
            Rationale: 'Increased risk of encephalopathy requiring hospitalization in older adults with eGFR <60 mL/min or who require chronic dialysis.',
            Recommendation: 'Avoid baclofen in older adults with impaired kidney function (eGFR <60 mL/min). When baclofen cannot be avoided, use the lowest effective dose and monitor for signs of CNS toxicity, including altered mental status.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 14,
            Drug_Category: 'Central nervous system and analgesics',
            Drug_Name: 'Duloxetine',
            CrCl: '<30',
            Rationale: 'Increased GI adverse effects (nausea, diarrhea)',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Weak',
        },
        {
            ID: 15,
            Drug_Category: 'Central nervous system and analgesics',
            Drug_Name: 'Gabapentin',
            CrCl: '<60',
            Rationale: 'CNS adverse effects',
            Recommendation: 'Reduce dose',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 16,
            Drug_Category: 'Central nervous system and analgesics',
            Drug_Name: 'Levetiracetam',
            CrCl: '≤80',
            Rationale: 'CNS adverse effects',
            Recommendation: 'Reduce dose',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 17,
            Drug_Category: 'Central nervous system and analgesics',
            Drug_Name: 'NSAIDs (non-selective, COX-2 selective, and nonacetylated salicylates, oral and parenteral)',
            CrCl: '<30',
            Rationale: 'May increase the risk of acute kidney injury and a further decline in kidney function',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 18,
            Drug_Category: 'Central nervous system and analgesics',
            Drug_Name: 'Pregabalin',
            CrCl: '<60',
            Rationale: 'CNS adverse effects',
            Recommendation: 'Reduce dose',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 19,
            Drug_Category: 'Central nervous system and analgesics',
            Drug_Name: 'Tramadol',
            CrCl: '<30',
            Rationale: 'CNS adverse effects',
            Recommendation: 'Immediate release: reduce dose\nExtended-release: avoid',
            Quality_of_Evidence: 'Low',
            Strength_of_Recommendation: 'Weak',
        },
        {
            ID: 20,
            Drug_Category: 'Gastrointestinal',
            Drug_Name: 'Cimetidine',
            CrCl: '<50',
            Rationale: 'Mental status changes',
            Recommendation: 'Reduce dose',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 21,
            Drug_Category: 'Gastrointestinal',
            Drug_Name: 'Famotidine',
            CrCl: '<50',
            Rationale: 'Mental status changes',
            Recommendation: 'Reduce dose',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 22,
            Drug_Category: 'Gastrointestinal',
            Drug_Name: 'Nizatidine',
            CrCl: '<50',
            Rationale: 'Mental status changes',
            Recommendation: 'Reduce dose',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 23,
            Drug_Category: 'Hyperuricemia',
            Drug_Name: 'Colchicine',
            CrCl: '<30',
            Rationale: 'GI, neuromuscular, and bone marrow toxicity',
            Recommendation: 'Reduce dose; monitor for adverse effects.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 24,
            Drug_Category: 'Hyperuricemia',
            Drug_Name: 'Probenecid',
            CrCl: '<30',
            Rationale: 'Loss of effectiveness',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        
    ];

    try {
        await collection.insertMany(userObjects1);
        console.log("Medications List Created!");
    } catch (err) {
        console.error("Failed to insert document:", err);
        throw err; // Propagate the error
    }
}

async function main() {
    try {
        await client.connect();
        console.log("Connected successfully to server");
        var db = client.db(dbName); //Use this database

        await insertMed(db);
    } catch (err) {
        console.error("Failed to connect to the server:", err);
    } finally {
        await client.close();
    }
}

main();
