var MongoClient = require("mongodb").MongoClient;
var connect = require("../connect"); // url from connect module
var client = new MongoClient(connect.database.url, {
    useUnifiedTopology: true,
});

var dbName = "Beers_Criteria"; // database name

// used javascript as initial language for manual insertion of data
// 2023 American Geriatrics Society Beers Criteria® for potentially clinically important drug–drug interactions that should be avoided in older adults.
async function insertMed(db) {
    var collection = db.collection('Table5');
    var userObjects1 = [
        {
            ID: 1,
            Drug_Name_Class: 'RAS inhibitors (ACEIs,ARBs, ARNIs, aliskiren) or potassium-sparing diuretics (amiloride, triamterene)',
            Interating_Drug: 'Another RAS inhibitor or a potassium-sparing diuretic',
            Risk_Rationale: 'Increased risk of hyperkalemia.',
            Recommendation: 'Avoid routinely using 2 or more RAS inhibitors, or a RAS inhibitor and potassium-sparing diuretic, concurrently in those with chronic kidney disease Stage 3a or higher.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 2,
            Drug_Name_Class: 'Opioids',
            Interating_Drug: 'Benzodiazepines',
            Risk_Rationale: 'Increased risk of overdose and adverse events.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 3,
            Drug_Name_Class: 'Opioids',
            Interating_Drug: ['Gabapentin', 'Pregabalin'],
            Risk_Rationale: 'Increased risk of severe sedation-related adverse events, including respiratory depression and death.',
            Recommendation: 'Avoid; exceptions are when transitioning from opioid therapy to gabapentin or pregabalin, or when using gabapentinoids to reduce opioid dose, although caution should be used in all circumstances.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 4,
            Drug_Name_Class: 'Anticholinergic',
            Interating_Drug: 'Anticholinergic',
            Risk_Rationale: 'Use of more than one medication with anticholinergic properties increases the risk of cognitive decline, delirium, and falls or fractures.',
            Recommendation: 'Avoid; minimize the number of anticholinergic drugs (Table 7).',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 5,
            Drug_Name_Class: ['Antiepileptics (including gabapentinoids)', 'Antidepressants (TCAs, SSRIs, and SNRIs)', 'Antipsychotics', 'Benzodiazepines', 'Nonbenzodiazepine benzodiazepine receptor agonist hypnotics (i.e., “Z-drugs”)', 'Opioids', 'Skeletal muscle relaxants'],
            Interating_Drug: 'Any combination of ≥3 of these CNS-active drugs',
            Risk_Rationale: 'Increased risk of falls and of fracture with the concurrent use of ≥3 CNS active agents (antiepileptics including gabapentinoids, antidepressants, antipsychotics, benzodiazepines, nonbenzodiazepine benzodiazepine receptor agonist hypnotics, opioids, and skeletal muscle relaxants).',
            Recommendation: 'Avoid concurrent use of ≥3 CNS-active drugs (among types as listed at left); minimize the number of CNS-active drugs.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 6,
            Drug_Name_Class: 'Lithium',
            Interating_Drug: ['ACEIs', 'ARBs', 'ARNIs'],
            Risk_Rationale: 'Increased risk of lithium toxicity.',
            Recommendation: 'Avoid; monitor lithium concentrations.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 7,
            Drug_Name_Class: 'Lithium',
            Interating_Drug: 'Loop diuretics',
            Risk_Rationale: 'Increased risk of lithium toxicity.',
            Recommendation: 'Avoid; monitor lithium concentrations.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 8,
            Drug_Name_Class: 'Non-selective peripheral alpha-1 blockers',
            Interating_Drug: 'Loop diuretics',
            Risk_Rationale: 'Increased risk of urinary incontinence in older women.',
            Recommendation: 'Avoid in older women, unless conditions warrant both drugs.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 9,
            Drug_Name_Class: 'Phenytoin',
            Interating_Drug: 'Trimethoprim-sulfamethoxazole',
            Risk_Rationale: 'Increased risk of phenytoin toxicity',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 10,
            Drug_Name_Class: 'Theophylline',
            Interating_Drug: 'Cimetidine',
            Risk_Rationale: 'Increased risk of theophylline toxicity',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 11,
            Drug_Name_Class: 'Theophylline',
            Interating_Drug: 'Ciprofloxacin',
            Risk_Rationale: 'Increased risk of theophylline toxicity',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 12,
            Drug_Name_Class: 'Warfarin',
            Interating_Drug: ['Amiodarone', 'Ciprofloxacin', 'Macrolides (excluding azithromycin)', 'Trimethoprim-sulfamethoxazole', 'SSRIs'],
            Risk_Rationale: 'Increased risk of bleeding.',
            Recommendation: 'Avoid when possible; if used together, monitor INR closely.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
    ];

    try {
        await collection.insertMany(userObjects1);
        console.log("Medications List Created!");
    } catch (err) {
        console.error("Failed to insert document:", err);
        throw err; // propagate the error
    }
}

async function main() {
    try {
        await client.connect();
        console.log("Connected successfully to server");
        var db = client.db(dbName); // use this database

        await insertMed(db);
    } catch (err) {
        console.error("Failed to connect to the server:", err);
    } finally {
        await client.close();
    }
}

main();
